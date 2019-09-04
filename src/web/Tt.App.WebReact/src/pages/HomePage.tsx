import React, { Component } from "react";
import { connect } from "react-redux";
import { toggleLogo } from "../store/actions/appActions";
import { State } from "../store/rootReducer";
import logo from "../assets/logo.svg";

interface DispatchProps {
  toggleLogo: () => void;
  showLogo: Boolean;
}

const HomePage = ({ toggleLogo, showLogo }: DispatchProps) => {
  return (
    <div>
      <button className="btn--primary" onClick={toggleLogo}>
        Toggle Logo!
      </button>
      {showLogo ? <img src={logo} alt="logo" /> : null}
    </div>
  );
};

const mapStateToProps = (state: State) => {
  return {
    showLogo: state.app.showLogo
  };
};

export default connect(
  mapStateToProps,
  { toggleLogo }
)(HomePage);
