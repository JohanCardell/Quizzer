import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Quiz extends Component {
    static displayName = Quiz.name;

    constructor(props) {
        super(props);
        this.state = {
            quizData: [],
            currentQuestionNumber: 0,
            answers: [],
            myAnswer: null,
            score: 0,
            disabled: true,
            isEnd: false,
            loading: true
        };
    }

    componentDidMount() {
        this.generateQuiz();
    }

    componentDidUpdate(prevProps, prevState) {
        if (this.state.currentQuestion !== prevState.currentQuestion) {
            this.setState(() => {
                return {
                    currentQuestion: this.quizData[this.state.currentQuestionNumber].question,
                    answers: this.questions[this.state.currentQuestionNumber].answers,
                    disabled: true,
                };
            });
        }
    }

    nextQuestionHandler = () => {
        // console.log('test')
        const { myAnswer, answer, score } = this.state;

        if (myAnswer === answer) {
            this.setState({
                score: score + 1
            });
        }
    }

    static renderQuizQuestions() {

        const { answers, myAnswer, currentQuestion, isEnd } = this.state;

        if (isEnd) {
            return (
                <div className="result">
                    <h3>Game Over your Final score is {this.state.score} points </h3>
                    <p>
                        The correct answers for the questions were
                        <ul>
                            {this.quizData.map((item, index) => (
                                <li className="ui floating message options" key={index}>
                                    {item.answer}
                                </li>
                            ))}
                        </ul>
                    </p>
                </div>
            );
        } else {
            return (
                <div >
                    <h1>{this.state.questions} </h1>
                    <span>{`Question ${this.currentQuestionNumber}  out of ${this.quizData.length -
                        1} remaining `}</span>
                    {answers.map(answer => (
                        <p
                            key={answer.id}
                            className={`ui floating message options
                             ${myAnswer === answer ? "selected" : null}
                             `}
                            onClick={() => this.checkAnswer(answer)}
                        >
                            {answer}
                        </p>
                    ))}
                    {this.currentQuestionNumber < this.quizData.length - 1 && (
                        <button
                            className="ui inverted button"
                            disabled={this.state.disabled}
                            onClick={this.nextQuestionHandler}
                        >
                            Next
                        </button>
                    )}
                    {/* //adding a finish button */}
                    {this.currentQuestionNumber === this.quizData.length - 1 && (
                        <button className="ui inverted button" onClick={this.finishHandler}>
                            Finish
                        </button>
                    )}
                </div>
            );
        }
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Quiz.renderQuizQuestions();

        return (
            <div>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async generateQuiz() {
        const token = await authService.getAccessToken();
        const response = await fetch('quiz', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });

        this.setState({
            quizData: response,
            currentQuestion: response[this.state.currentQuestionNumber].text,
            answers: response[this.state.currentQuestionNumber].answers,
            loading: false
        });
    }
}
