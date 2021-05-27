@editUserInformation @api
Feature: ApiEditUserInformation

Scenario Outline: It is possible change email to valid email with API request
	Given New Client is created
	When I send POST request https://api.newbookmodels.com/api/v1/client/change_email/ with '<uniqueEmail>'
	Then Then Client email was changed to '<usedUniqueEmail>' in NewBookModels Account
Examples:
	| uniqueEmail | usedUniqueEmail |
	| uniqueEmail | usedUniqueEmail |

Scenario Outline: It is possible change phone to valid phone with API request
	Given New Client is created
	When I send POST request https://api.newbookmodels.com/api/v1/client/change_phone/ with '<newPhone>'
	Then Then Client phone was changed to '<newPhone>' in NewBookModels Account
Examples:
	| newPhone   |
	| 4131424545 |

Scenario Outline: It is possible change password to valid password with API request
	Given New Client is created
	When I send POST request https://api.newbookmodels.com/api/v1/password/change/ with '<newPassword>'
	Then Then Client password was changed in NewBookModels Account
Examples:
	| newPassword |
	| 123Qasg(@34 |

Scenario Outline: It is possible change Primary Account Holder Name to valid Primary Account Holder Name with API request
	Given New Client is created
	When I send PATCH request https://api.newbookmodels.com/api/v1/client/self/ with '<newFirstName>' and '<newLastName>'
	Then Then Client Primary Account Holder Name was changed to '<newName>' in NewBookModels Account
Examples:
	| newFirstName | newLastName | newName     |
	| Willy        | Wonka       | Willy Wonka |