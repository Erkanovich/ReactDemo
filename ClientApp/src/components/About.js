import React, { Component } from "react";
import { WorkCard } from "./WorkCard";

export class About extends Component {
  render() {
    return (
      <div>
        <h1>This is my about page</h1>
        <p>
          This is where I will have all my work and education related
          information
        </p>
        {/* We begin with work related information */}
        <div className="row">
          <div className="col-md-4">
            <WorkCard
              header="Codic Education"
              title="Educator"
              text="Working as a teacher for higher education schools"
            ></WorkCard>
          </div>
          <div className="col-md-4">
            <WorkCard
              header="Autocom"
              title="Full stack developer"
              text="Programming and shit yo"
            ></WorkCard>
          </div>
          <div className="col-md-4">
            <WorkCard
              header="Hogia"
              title="Star Evangelist"
              text="On-boarding education for newly hired developers"
            ></WorkCard>
          </div>
        </div>
      </div>
    );
  }
}
