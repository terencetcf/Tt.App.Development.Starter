import React from "react";
import { Form } from "./Form";
import { Field, IFieldKvp } from "./Field";

const reasons: IFieldKvp[] = [
  { value: "", display: "" },
  { value: "Marketing", display: "Marketing" },
  { value: "Support", display: "Support" },
  { value: "Feedback", display: "Feedback" },
  { value: "Jobs", display: "Jobs" }
];

export const ApplicationForm: React.FunctionComponent = () => {
  return (
    <Form
      render={() => (
        <>
          <div className="alert alert-info" role="alert">
            Enter the information below and we'll get back to you as soon as we
            can.
          </div>
          <Field id="name" label="Name" />
          <Field id="email" label="Email" />
          <Field
            id="reason"
            label="Reason"
            editor="dropdown"
            options={reasons}
          />
          <Field id="notes" label="Notes" editor="multilinetextbox" />
        </>
      )}
    />
  );
};
