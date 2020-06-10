import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';

export class Home extends Component {

    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            userName: authService.getUser().userName,
        };
        
    }

    componentDidMount() {
        this.setState = {
            userName: authService.getUser().userName,
        };
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
