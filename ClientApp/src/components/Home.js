import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';

export class Home extends Component {

    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            isAuthenticated: false,
            userName: null
        };
    }

    componentDidMount() {
        this.populateState();
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            userName: user && user.name
        });
    }

    render() {
        let name = "stranger";
        if (this.state.userName !== null) {
            name = this.state.userName;
        }
       
        return (
            <div>
                <h1>Welcome, {name}</h1>
            </div>
        );

    }
}
