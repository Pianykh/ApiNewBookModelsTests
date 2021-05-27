@editUserInformation @api
Feature: ApiEditUserInformation

Scenario Outline: It is possible change email to valid email with API request
	Given New Client is created
	When I send POST request https://api.newbookmodels.com/api/v1/client/change_email/ with '<uniqueEmail>'
	Then Then Client email was changed to '<usedUniqueEmail>' in NewBookModels Account
Examples:
	| uniqueEmail | usedUniqueEmail |
	| uniqueEmail | usedUniqueEmail |