import { IApplicantModel } from "./IApplicantModel";
import { IProductModel } from "./IProductModel";

export interface IApplicationModel {
  id?: string;
  applicants?: IApplicantModel[];
  selectedProducts?: IProductModel[];
}
