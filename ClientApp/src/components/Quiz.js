import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';

export class Quiz extends Component {
    static displayName = Quiz.name;

    constructor(props) {
        super(props);
        this.state = {
            isAuthenticated: false,
            userName: null,
            currentQuestionIndex: 0,
            questions: [],
            options: [],
            loading: true,
            selectedOption: null,
            disabled: true,
            isFinished: false,
            score: 0,

        };
        this.optionClickHandler = this.optionClickHandler.bind(this);
        this.nextQuestionHandler = this.nextQuestionHandler.bind(this);
    }


    componentDidMount() {
        this.generateQuiz();
        this.populateState();
    }

    componentDidUpdate(prevProps, prevState) {
        if (this.state.currentQuestionIndex !== prevState.currentQuestionIndex) {
            this.setState(() => {
                return {
                    disabled: true,
                    options: this.state.questions[this.state.currentQuestionIndex].options,
                    selectedOption: null
                };
            });
        }
    }

    nextQuestionHandler = () => {
        const { questions, selectedOption, score, currentQuestionIndex } = this.state;

        if (selectedOption.isCorrect) {
            this.setState({
                score: score + 1
            });
        }

        const nextQuestionIndex = currentQuestionIndex + 1;
        const shuffledOptions = this.shuffleOptions(questions[nextQuestionIndex].options);

        this.setState({
            currentQuestionIndex: nextQuestionIndex,
            options: shuffledOptions
        });
    };

    optionClickHandler = answer => {
        this.setState({
            selectedOption: answer,
            disabled: false
        });
    };

    finishHandler = () => {
        const { selectedOption, score, questions, currentQuestionIndex } = this.state;
        const date = new Date();
        if (currentQuestionIndex === questions.length - 1) {
            this.setState({
                isFinished: true,
                timeStamp: date
            });
        }
        if (selectedOption.isCorrect) {
            this.setState({
                score: score + 1
            });
        }

    };

    render() {
        const { score, loading, questions, options, selectedOption, currentQuestionIndex, disabled, isFinished } = this.state;

        let countDisplay = <p>{currentQuestionIndex + 1}/{questions.length}</p>

        let nextOrFinishButton;

        if (currentQuestionIndex === questions.length-1) {
            nextOrFinishButton = <button disabled={disabled} onClick={this.finishHandler}>Finish</button>
        }
        else {
            nextOrFinishButton = <button disabled={disabled} onClick={this.nextQuestionHandler.bind(this)}>Next</button>
        }

        if (loading) {
            return (
                <p><em>Loading...</em></p>
            );
        }
        else if (isFinished) {
            this.insertScore();
            return (
                <div className="scorePage">
                    <h2>You scored {score} out of {questions.length}</h2>
                </div>
             );
        }
        else {
            return (
                <div className="quiz" key="quiz">
                    <h1>{questions[currentQuestionIndex].text} </h1>
                    {countDisplay}
                        {options.map((option, index) => (
                            <p key={index}>
                                <button
                                    className={` option-button ${selectedOption === option ? "selected" : null}`}
                                    onClick={ ()=> this.optionClickHandler( option)}
                                    value={option.text}
                            >
                                {option.text}
                                </button>
                            </p>
                        ))}
                    {nextOrFinishButton}
                </div>
            );
        }
    }

     shuffleOptions(options) {
        var currentIndex = options.length, temporaryValue, randomIndex;

        while (0 !== currentIndex) {

            randomIndex = Math.floor(Math.random() * currentIndex);
            currentIndex -= 1;

            temporaryValue = options[currentIndex];
            options[currentIndex] = options[randomIndex];
            options[randomIndex] = temporaryValue;
        }
        return options;
    }

    async insertScore() {
        const token = await authService.getAccessToken();
        const response = await fetch('highscore', {
            method: "POST",
            body: JSON.stringify({ PlayerName: this.state.userName, Score: this.state.score}),
            headers: !token ? {} : { 'Authorization': `Bearer ${token}`, 'Content-Type': 'application/json' }
        });
    };


    async generateQuiz() {
        const token = await authService.getAccessToken();
        const response = await fetch('quiz', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({
            questions: data,
            options: data[this.state.currentQuestionIndex].options,
            loading: false
        });
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            userName: user && user.name
        });
    }
}
