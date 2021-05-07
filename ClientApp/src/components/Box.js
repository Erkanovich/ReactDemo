import React, { Component } from 'react';
import './Box.css';

export class Box extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="box_of_doom"></div>
      );
  }
}