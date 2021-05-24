import React, { Component } from "react";

export class WorkCard extends Component {
  render() {
    return (
      <div class="card">
        <div class="card-header">{this.props.header}</div>
        <div class="card-body">
          <h5 class="card-title">{this.props.title}</h5>
          <p class="card-text">
          {this.props.text}
          </p>
        </div>
      </div>
    );
  }
}
