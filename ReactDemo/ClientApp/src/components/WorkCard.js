import React, { Component } from "react";

export class WorkCard extends Component {
  render() {
    return (
      <div className="card">
        <div className="card-header">{this.props.header}</div>
        <div className="card-body">
          <h5 className="card-title">{this.props.title}</h5>
          <p className="card-text">
          {this.props.text}
          </p>
        </div>
      </div>
    );
  }
}
