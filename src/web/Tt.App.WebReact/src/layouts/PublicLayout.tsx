import Menu from "../components/shared/Menu";
import * as React from "react";
import { ToastContainer } from "react-toastify";
import Footer from "../components/shared/Footer";

interface IProps {
  children?: React.ReactNode;
}

type Props = IProps;

export default class PublicLayout extends React.Component<Props, {}> {
  public render() {
    return (
      <div id="publicLayout">
        <Menu />
        <main className="container container-main" role="main">
          {this.props.children}
        </main>
        <ToastContainer />
        <Footer />
      </div>
    );
  }
}
