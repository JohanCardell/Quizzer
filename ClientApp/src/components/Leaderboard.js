import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';

export class Leaderboard extends Component {
    static displayName = Leaderboard.name;

    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            scoreEntries: []
        };
    }


    componentDidMount() {
        this.getHighScore();
    }

    render() {
        const {scoreEntries} = this.state;
        if (this.loading) {
            return (
                <p><em>Loading...</em></p>
            );
        }
        else {
            return (
                <div className='table table-striped'>
                    <h1> Top ten scores </h1>
                    <table className="striped">
                        <thead>
                            <tr>
                                <th> Score </th>
                                <th> Date </th>
                                <th> Player </th>
                            </tr>
                        </thead>
                        <tbody>
                            {scoreEntries.map((entry, index) => (
                                <tr key={index}>
                                    <td>{entry.score}</td>
                                    <td>{entry.entryDate}</td>
                                    <td>{entry.playerName}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            );
        }
    }

    async getHighScore() {
        const token = await authService.getAccessToken();
        const response = await fetch('highscore', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
       
        const data = await response.json();
        console.log(data);
        this.setState({
            scoreEntries: data,
            loading: false
        });
    }



}

