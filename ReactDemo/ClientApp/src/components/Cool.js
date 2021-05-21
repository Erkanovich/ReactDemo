import React, { Component } from 'react';
import { Box } from './Box';

// This component can be navigated to.
export class Cool extends Component {
  constructor(props) {
    console.log(props);
    super(props);
  }

  // renders the component
  render() {
    let allMyBoxes = [];
    for (let i = 0; i < 100; i++) {
      allMyBoxes.push(<Box key={i}></Box>);
    }
    console.log(allMyBoxes.length);
    return (
      <div>
        <h1>This is a cool page</h1>
        {allMyBoxes}
      </div>
      );
  }
}