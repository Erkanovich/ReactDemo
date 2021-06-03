import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  numberOfRepos = 0;

  constructor() {
    super();
    this.state = {
      numberOfRepos: 0
    }
  }


  componentDidMount() {
    fetch('https://api.github.com/users/erkanovich/repos')
    .then(response => response.json())
    .then(json => {
      this.setState({
        numberOfRepos: json.length
      })
    });
  }

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Number of repos in my github right now: {this.state.numberOfRepos}</p>
      </div>
    );
  }
}
