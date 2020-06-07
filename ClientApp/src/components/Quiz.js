import React from "react";

class Quiz extends React.Component {
    state = {
        currentQuestion: 0,
        myAnswer: null,
        options: [],
        score: 0,
        disabled: true,
        isEnd: false
    };

    loadQuizData = () => {
        // console.log(quizData[0].question)
        this.setState(() => {
            return {
                questions: quizData[this.state.currentQuestion].question,
                answer: quizData[this.state.currentQuestion].answer,
                options: quizData[this.state.currentQuestion].options
            };
        });
    };

    componentDidMount() {
        this.loadQuizData();
    }
    nextQuestionHandler = () => {
        // console.log('test')
        const { myAnswer, answer, score } = this.state;

        if (myAnswer === answer) {
            this.setState({
                score: score + 1
            });
        }

        this.setState({
            currentQuestion: this.state.currentQuestion + 1
        });
        console.log(this.state.currentQuestion);
    };

    componentDidUpdate(prevProps, prevState) {
        if (this.state.currentQuestion !== prevState.currentQuestion) {
            this.setState(() => {
                return {
                    disabled: true,
                    questions: quizData[this.state.currentQuestion].question,
                    options: quizData[this.state.currentQuestion].options,
                    answer: quizData[this.state.currentQuestion].answer
                };
            });
        }
    }
    //check answer
    checkAnswer = answer => {
        this.setState({ myAnswer: answer, disabled: false });
    };
    finishHandler = () => {
        if (this.state.currentQuestion === quizData.length - 1) {
            this.setState({
                isEnd: true
            });
        }
        if (this.state.userAnswer === this.state.correctAnswer) {
            this.setState({
                score: this.state.score + 1
            });
        }
    };
    render() {
        const { options, myAnswer, currentQuestion, isEnd } = this.state;

        if (isEnd) {
            return (
                <div className="result">
                    <h3>Game Over your Final score is {this.state.score} points </h3>
                    <p>
                        The correct answer's for the questions was
            <ul>
                            {quizData.map((item, index) => (
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
                <div className="App">
                    <h1>{this.state.questions} </h1>
                    <span>{`Questions ${currentQuestion}  out of ${quizData.length -
                        1} remaining `}</span>
                    {options.map(option => (
                        <p
                            key={option.id}
                            className={`ui floating message options
         ${myAnswer === option ? "selected" : null}
         `}
                            onClick={() => this.checkAnswer(option)}
                        >
                            {option}
                        </p>
                    ))}
                    {currentQuestion < quizData.length - 1 && (
                        <button
                            className="ui inverted button"
                            disabled={this.state.disabled}
                            onClick={this.nextQuestionHandler}
                        >
                            Next
                        </button>
                    )}
                    {/* //adding a finish button */}
                    {currentQuestion === quizData.length - 1 && (
                        <button className="ui inverted button" onClick={this.finishHandler}>
                            Finish
                        </button>
                    )}
                </div>
            );
        }
    }
}

export default Quiz;
