import React, { Component } from 'react';

export class FetchData extends Component {
  // class-property
  static displayName = FetchData.name;

  // Constructor is techically part of the lifecycle.
  // Read more about lifecycle here: https://reactjs.org/docs/react-component.html
  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  // Lifecycle method.
  componentDidMount() {
    this.populateWeatherData();
  }

  // Called from render() method
  // returns the table with forecasts
  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  // Lifecycle method. Required.
  // Renders the page.
  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  // Fetches data from the backend
  async populateWeatherData() {
    // response includes everything from a http-request including headers etc.
    const response = await fetch('weatherforecast');
    // response.json() looks in the body for json data and parses it.
    const data = await response.json();
    // https://reactjs.org/docs/faq-state.html#what-does-setstate-do
    this.setState({ forecasts: data, loading: false });
  }
}
