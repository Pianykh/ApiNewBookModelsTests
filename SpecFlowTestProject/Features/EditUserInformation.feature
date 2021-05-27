@editUserInformation @ui
Feature: EditUserInformation
	In order to actualize my credentials in NewBookModels
	As a client of NewBookModels
	I want to be able edit information in my account page in NewBookModels

Scenario: It is possible change email to valid email in account page in NewBookModels
	Given Client is created
	And Client is authorized
	And Account settings page is opened
	When I open edit email adress block
	And I input '<password>' in Current Password field
	And I input '<newEmail>' in New E-mail Address field
	And I save changes in edit email adress block
	Then Email is changed to '<usedUniqueEmail>'
Examples:
	| password                | newEmail    | usedUniqueEmail |
	| default client password | uniqueEmail | usedUniqueEmail |

Scenario: It is possible change phone to valid phone in account page in NewBookModels
	Given Client is created
	And Client is authorized
	And Account settings page is opened
	When I open edit phone block
	And I input '<password>' in Current Password field
	And I input '<newPhone>' in New Phone Number field
	And I save changes in edit phone block
	Then Phone number is changed to '<newPhone>'
Examples:
	| password                | newPhone   |
	| default client password | 1233211212 |

Scenario: It is possible change password to valid password in account page in NewBookModels
	Given Client is created
	And Client is authorized
	And Account settings page is opened
	When I open edit password block
	And I input '<password>' in Current Password field in Edit Password block
	And I input '<newPassword>' in New Password field and Re-type New Password field	
	And I save changes in edit password block
	And I log out
	And I open Sign In page
	And I input email of created client in email field
	And I input new password '<newPassword>' in Password field
	And I click log in button
	Then Successfully logged in NewBookModels as created client
Examples:
	| password                | newPassword        |
	| default client password | 1Qazxcdeqw((@@4428 |