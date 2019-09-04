import * as React from "react";
import { withRouter } from "react-router";
import { NavLink, Redirect } from "react-router-dom";
// import { Dropdown, Collapse } from "bootstrap";

class TopMenu extends React.Component<{}> {
  constructor(props) {
    super(props);
  }

  //   private elDropdown: HTMLAnchorElement;
  //   private elCollapseButton: HTMLButtonElement;

  componentDidMount() {
    // var dropdown = new Dropdown(this.elDropdown);
    // var collapse = new Collapse(this.elCollapseButton);
  }

  componentDidUpdate() {}

  render() {
    return (
      <nav className="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
        <a className="navbar-brand" href="#">
          Navbar
        </a>
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbars"
          aria-controls="navbars"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbars">
          <ul className="navbar-nav mr-auto">
            <li className="nav-item">
              <NavLink
                exact
                to={"/"}
                activeClassName="active"
                className="nav-link"
              >
                Home
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink
                exact
                to={"/Apply"}
                activeClassName="active"
                className="nav-link"
              >
                Apply
              </NavLink>
            </li>
            <li className="nav-item">
              <a className="nav-link disabled" href="#">
                Disabled
              </a>
            </li>
            <li className="nav-item dropdown">
              <a
                className="nav-link dropdown-toggle"
                href="http://example.com"
                id="dropdown01"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                Dropdown
              </a>
              <div className="dropdown-menu" aria-labelledby="dropdown01">
                <a className="dropdown-item" href="#">
                  Action
                </a>
                <a className="dropdown-item" href="#">
                  Another action
                </a>
                <a className="dropdown-item" href="#">
                  Something else here
                </a>
              </div>
            </li>
          </ul>
        </div>
      </nav>
    );
  }
}

export default withRouter(TopMenu as any);
