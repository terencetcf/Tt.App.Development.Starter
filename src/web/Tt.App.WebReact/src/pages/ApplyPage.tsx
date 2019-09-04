import * as React from "react";
import { connect } from "react-redux";
import { State } from "../store/rootReducer";
import { Helmet } from "react-helmet";
import { ApplicationForm } from "../components/shared/ApplicationForm";

interface DispatchProps {
  isLoading: Boolean;
}

export class ApplyPage extends React.Component<DispatchProps, {}> {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <>
        <Helmet>
          <title>Apply for an account - Tt React Web App</title>
        </Helmet>
        <h1>Apply for an account</h1>
        <ApplicationForm></ApplicationForm>
      </>
    );
  }
}

const mapStateToProps = (state: State) => {
  return {
    isLoading: state.app.showLogo
  };
};

export default connect(
  mapStateToProps,
  {}
)(ApplyPage);
