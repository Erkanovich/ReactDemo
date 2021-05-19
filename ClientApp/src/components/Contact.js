import React, { Component } from "react";

export class Contact extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      name: "",
      message: ""
    };

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleSubmit(event) {
    // here we will send the data to the server!
    fetch('/contacts', {
      method: 'POST',
      body: JSON.stringify(this.state),
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(response => {
      console.log(response);
      response.json().then(jsonContent => {
        console.log(jsonContent);
      });
    });
    
    event.preventDefault();
  }

  handleInputChange(event) {
    let theElement = event.target;
    let nameOfTheElement = theElement.name;
    let valueOfTheElement = theElement.value;
    this.setState({ [nameOfTheElement]: valueOfTheElement });
  }

  render() {
    return (
      <div>
        <h1>This is my contact me page</h1>
        <p>Do I seem like a cool dude? Contact me below:</p>
        <form onSubmit={this.handleSubmit}>
          <div class="form-group">
            <label for="formGroupExampleInput">Your email</label>
            <input
              name="email"
              type="text"
              class="form-control"
              id="formGroupExampleInput"
              placeholder="example@email.com"
              onChange={this.handleInputChange}
              value={this.state.email}
            />
          </div>
          <div class="form-group">
            <label for="formGroupExampleInput2">Your name</label>
            <input
              name="name"
              type="text"
              class="form-control"
              id="formGroupExampleInput2"
              placeholder="Your name here"
              onChange={this.handleInputChange}
              value={this.state.name}
            />
          </div>
          <div class="form-group">
            <label for="formGroupExampleInput2">Message</label>
            <textarea
              class="form-control"
              rows="5"
              value={this.state.message}
              onChange={this.handleInputChange}
              name="message"
            ></textarea>
          </div>
          <div class="form-group">
            <input type="submit" class="btn btn-primary" value="Send" />
          </div>
        </form>
      </div>
    );
  }
}
