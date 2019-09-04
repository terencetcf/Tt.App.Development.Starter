import * as React from "react";
import * as DateUtils from "../../utils/datetimeUtils";

export default class Footer extends React.Component<{}, {}> {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <footer className="footer text-center">
        <div>
          Copyright (c) {DateUtils.getYear()} Terence Tai
          {" | "}
          <a href="https://en.wikipedia.org/wiki/MIT_License">MIT License</a>
        </div>
      </footer>
    );
  }
}
