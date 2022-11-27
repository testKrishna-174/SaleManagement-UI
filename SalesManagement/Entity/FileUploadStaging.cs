using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Entity
{
    public class FileUploadStaging
    {
		public Int64 Id { get; set; }
		public Int64 FileId							{ get; set; }
		public string Date_Entered					{ get; set; }
		public string Source						{ get; set; } 
		public string Supervisor_First_Name			{ get; set; }
		public string Supervisor_Middle_Initial		{ get; set; }
		public string Supervisor_Last_Name			{ get; set; }
		public string Salesperson_First_Name		{ get; set; }
		public string Salesperson_Middle_Initial	{ get; set; }
		public string Salesperson_Last_Name			{ get; set; }
		public string COMPANY_NAME					{ get; set; }
		public string ADDRESS						{ get; set; }
		public string CITY							{ get; set; }
		public string STATE							{ get; set; }
		public string ZIPCODE						{ get; set; }
		public string County						{ get; set; }
		public string PHONE_NUMBER					{ get; set; }
		public string WEBADDRESS					{ get; set; }
		public string LAST_NAME						{ get; set; }
		public string FIRST_NAME					{ get; set; }
		public string CONTACT_TITLE					{ get; set; }
		public string ACTUAL_EMPLOYEE_SIZE			{ get; set; }
		public string EMPLOYEE_SIZE_RANGE			{ get; set; }
		public string ACTUAL_SALES_VOLUME			{ get; set; }
		public string SALES_VOLUME_RANGE			{ get; set; }
		public string PRIMARY_SIC					{ get; set; }
		public string PRIMARY_SIC_DESCRIPTION		{ get; set; }
		public string SECONDARY_SIC_1				{ get; set; }
		public string SECONDARY_SIC_DESCRIPTION_1	{ get; set; }
		public string SECONDARY_SIC_2				{ get; set; }
		public string SECONDARY_SIC_DESCRIPTION_2	{ get; set; }
		public string CREDIT_NUMERIC_SCORE			{ get; set; }
		public string HEADQUARTERS_BRANCH			{ get; set; }
		public string FIRM_INDIVIDUAL				{ get; set; }
		public string PUBLIC_PRIVATE_FLAG			{ get; set; }
		public string EXECUTIVE_EMAIL				{ get; set; }
		public string NOTES							{ get; set; }
		public string LOCATION_ADDRESS				{ get; set; }
		public string LOCATION_ADDRESS_CITY			{ get; set; }
		public string LOCATION_ADDRESS_STATE		{ get; set; }
		public string LOCATION_ADDRESS_ZIP			{ get; set; }
		public string LOCATION_COUNTY				{ get; set; }
		public bool   IsProcessed					{ get; set; }

		public static FileUploadStaging FromCsv(string csvLine)
		{
			string[] values = csvLine.Split(',');
			FileUploadStaging fileValues = new FileUploadStaging();
			//return fileValues;
			fileValues.Date_Entered						= Convert.ToString(values[0]);
			fileValues.Source							= Convert.ToString(values[1]);
			fileValues.Supervisor_First_Name		    = Convert.ToString(values[2]);
			fileValues.Supervisor_Middle_Initial	    = Convert.ToString(values[3]);
			fileValues.Supervisor_Last_Name			    = Convert.ToString(values[4]);
			fileValues.Salesperson_First_Name		    = Convert.ToString(values[5]);
			fileValues.Salesperson_Middle_Initial	    = Convert.ToString(values[6]);
			fileValues.Salesperson_Last_Name		    = Convert.ToString(values[7]);
			fileValues.COMPANY_NAME					    = Convert.ToString(values[8]);
			fileValues.ADDRESS						    = Convert.ToString(values[9]);
			fileValues.CITY							    = Convert.ToString(values[10]);
			fileValues.STATE						    = Convert.ToString(values[11]);
			fileValues.ZIPCODE						    = Convert.ToString(values[12]);
			fileValues.County						    = Convert.ToString(values[13]);
			fileValues.PHONE_NUMBER					    = Convert.ToString(values[14]);
			fileValues.WEBADDRESS					    = Convert.ToString(values[15]);
			fileValues.LAST_NAME					    = Convert.ToString(values[16]);
			fileValues.FIRST_NAME					    = Convert.ToString(values[17]);
			fileValues.CONTACT_TITLE				    = Convert.ToString(values[18]);
			fileValues.ACTUAL_EMPLOYEE_SIZE			    = Convert.ToString(values[19]);
			fileValues.EMPLOYEE_SIZE_RANGE			    = Convert.ToString(values[20]);
			fileValues.ACTUAL_SALES_VOLUME			    = Convert.ToString(values[21]);
			fileValues.SALES_VOLUME_RANGE			    = Convert.ToString(values[22]);
			fileValues.PRIMARY_SIC					    = Convert.ToString(values[23]);
			fileValues.PRIMARY_SIC_DESCRIPTION		    = Convert.ToString(values[24]);
			fileValues.SECONDARY_SIC_1				    = Convert.ToString(values[25]);
			fileValues.SECONDARY_SIC_DESCRIPTION_1	    = Convert.ToString(values[26]);
			fileValues.SECONDARY_SIC_2				    = Convert.ToString(values[27]);
			fileValues.SECONDARY_SIC_DESCRIPTION_2	    = Convert.ToString(values[28]);
			fileValues.CREDIT_NUMERIC_SCORE			    = Convert.ToString(values[29]);
			fileValues.HEADQUARTERS_BRANCH			    = Convert.ToString(values[30]);
			fileValues.FIRM_INDIVIDUAL				    = Convert.ToString(values[31]);
			fileValues.PUBLIC_PRIVATE_FLAG			    = Convert.ToString(values[32]);
			fileValues.EXECUTIVE_EMAIL				    = Convert.ToString(values[33]);
			fileValues.NOTES						    = Convert.ToString(values[34]);
			fileValues.LOCATION_ADDRESS				    = Convert.ToString(values[35]);
			fileValues.LOCATION_ADDRESS_CITY		    = Convert.ToString(values[36]);
			fileValues.LOCATION_ADDRESS_STATE		    = Convert.ToString(values[37]);
			fileValues.LOCATION_ADDRESS_ZIP			    = Convert.ToString(values[38]);
			fileValues.LOCATION_COUNTY					= Convert.ToString(values[39]);
			return fileValues;

		}

	}
}
