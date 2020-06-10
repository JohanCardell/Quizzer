import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';

export class Quiz extends Component {
    static displayName = Quiz.name;

    constructor(props) {
        super(props);
        this.state = {
            userId: authService.getUser().userId,
            currentQuestion: 0,
            questions: [],
            options: [],
            loading: true,
            selectedOption: null,
            disabled: true,
            isFinished: false,
            score: 0

        };
        this.optionClickHandler = this.optionClickHandler.bind(this);
        this.nextQuestionHandler = this.nextQuestionHandler.bind(this)
    }


    componentDidMount() {
        this.generateQuiz();
    }

    componentDidUpdate(prevProps, prevState) {
        if (this.state.currentQuestion !== prevState.currentQuestion) {
            this.setState(() => {
                return {
                    disabled: true,
                    options: this.state.questions[this.state.currentQuestion].options,
                    selectedOption: null
                };
            });
        }
    }

    nextQuestionHandler =() => {
        const { selectedOption, score, currentQuestion } = this.state;


        if (selectedOption.isCorrect) {
            this.setState({
                score: score + 1
            });
        }
        
        this.setState({
            currentQuestion: currentQuestion + 1
        });
    };
  
    optionClickHandler = answer => {
        this.setState({
            selectedOption: answer,
            disabled: false
        });
    };
  
    finishHandler = () => {
        const { selectedOption, score, questions, currentQuestion } = this.state;
        if (currentQuestion === questions.length - 1) {
            this.setState({
                isFinished: true
            });
        }
        if (selectedOption.isCorrect) {
            this.setState({
                score: score + 1
            });
        }
       
    };

    resetState = () => {
        this.setState = {
            userName: authService.getUser().username,
            currentQuestion: 0,
            questions: [],
            options: [],
            loading: true,
            selectedOption: null,
            disabled: true,
            isFinished: false,
            score: 0
        };
    }

    playAgainHandler = () => {

    };

    goToLeaderboard = () => {

    };

    
    render() {
        const { score, loading, questions, options, selectedOption, currentQuestion, disabled, isFinished } = this.state;

        let counter = <p>{currentQuestion + 1}/{questions.length}</p>
        //Next or Finish button
        let button;
        if (currentQuestion === questions.length-1) {
            button = <button className="ui inverted button" disabled={disabled} onClick={this.finishHandler}>Finish</button>
        }
        else {
            button = <button className="ui inverted button" disabled={disabled} onClick={this.nextQuestionHandler.bind(this)}>Next</button>
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
                <div className= "quiz">
                    <h1>{questions[currentQuestion].text} </h1>
                    {counter}
                    <ol>
                        {options.map((option, index) => (
                            <li key={index}>
                                <button
                                    className={` option-button ${selectedOption === option ? "selected" : null}`}
                                    onClick={ ()=> this.optionClickHandler( option)}
                                    value={option.text}
                            >
                                {option.text}
                                </button>
                            </li>
                        ))}
                    </ol>
                    {button}
                </div>
            );
        }
    }

    async insertScore() {
        const token = await authService.getAccessToken();
        const response = await fetch('api/highscores', {
            method: "POST",
            body: JSON.stringify({ userName: this.state.userName, score: this.state.score }),
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const result = await response.json();
        console.log(result);
        this.resetState();
    };
   

    async generateQuiz() {
        const token = await authService.getAccessToken();
        const response = await fetch('quiz', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({
            questions: data,
            options: data[this.state.currentQuestion].options,
            loading: false
        });
    }
}
