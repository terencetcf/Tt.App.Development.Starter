import React from "react";
import { Switch } from "react-router";
import { AppRoute } from "../components/shared/AppRoute";
import PublicLayout from "../layouts/PublicLayout";
import HomePage from "../pages/HomePage";
import ApplyPage from "../pages/ApplyPage";

const routes = (
  <div>
    <Switch>
      <AppRoute layout={PublicLayout} exact path="/" component={HomePage} />
      <AppRoute
        layout={PublicLayout}
        exact
        path="/apply"
        component={ApplyPage}
      />
    </Switch>
  </div>
);

export default routes;
