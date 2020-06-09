import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Quiz extends Component {
    static displayName = Quiz.name;

    constructor(props) {
        super(props);
        this.state = {
            currentQuestion: 0,
            questions: [],
            options: [],
            loading: true,
            selectedOption: null,
            disabled: true,
            isFinished: false,
            score: 0

        };
        this.handleOptionClick = this.optionClickHandler.bind(this);
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

    nextQuestionHandler = () => {
        const { selectedOption, score, currentQuestion } = this.state;

        if (selectedOption.iscorrect) {
            this.setState({
                score: score + 1
            });
        }

        this.setState({
            currentQuestion: currentQuestion + 1
        });
    };
  
    optionClickHandler(answer) {
        this.setState({
            selectedOption: answer,
            disabled: false
        });
    }
  
    finishHandler = () => {
        const { selectedOption, score, questions, currentQuestion } = this.state;
        if (currentQuestion === questions.length - 1) {
            this.setState({
                isFinished: true
            });
        }
        if (selectedOption.iscorrect) {
            this.setState({
                score: score + 1
            });
        }
        console.log(score);
    };

    playAgainHandler = () => {

    }

    goToLeaderboard = () => {

    }
          
    render() {
        const { score, loading, questions, options, selectedOption, currentQuestion, disabled, isFinished } = this.state;

        let counter = <p>{currentQuestion + 1}/{questions.length}</p>
        //Next or Finish button
        let button;
        if (currentQuestion === questions.length-1) {
            button = <button className="ui inverted button" disabled={disabled} onClick={this.finishHandler}>Finish</button>
        }
        else {
            button = <button className="ui inverted button" disabled={disabled} onClick={this.nextQuestionHandler}>Next</button>
        }
       
        if (loading) {
            return (
                <p><em>Loading...</em></p>
            );
        }
        else if (isFinished) {
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
                                    onClick={this.optionClickHandler.bind(this, option)}
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
