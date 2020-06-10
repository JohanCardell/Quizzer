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
        this.getTopTenScores();
    }

    render() {
        const {scoreEntries} = this.state;
        if (this.loading) {
            return (
                <p><em>Loading...</em></p>
            );
        }
        else if (scoreEntries === null)
            return (
                <p><em>There are no entries</em></p>
            );
        else {
            return (
                <div className="leaderboard">
                    <h1> Top ten scores </h1>
                    <table className="striped">
                        <tr>
                            <th> Score </th>
                            <th> Date </th>
                            <th> Player </th>
                        </tr>
                        {
                            scoreEntries.map((entry, index) => (
                                <tr key={index}>
                                    <td>{entry.score}</td>
                                    <td>{entry.entrydate}</td>
                                    <td>{entry.quizplayer.username}</td>
                                </tr>
                            ))
                        } 
                    </table>
                </div>
            );
        }
    }


    async getTopTenScores() {
        const token = await authService.getAccessToken();
        const response = await fetch('score', {
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

