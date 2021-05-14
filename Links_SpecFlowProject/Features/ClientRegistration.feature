Feature: ClientRegistration
Testing client registration form

@registerPrivateEntityClient
#Scenario Outline: Register as a private individual client
#	Given The user navigates to the web application Home page
#	And The user naviagates to the registration form
#	When The user fills in all the information on the registration form '<gender>', '<firstName>', '<lastName>', '<birthDate>', '<email>', '<streetAddress>', '<zipPostalCode>', '<city>', '<country>', '<phone>', '<newsletter>', '<password>', '<confirmPassword>'
#	And He clicks on the Submit Registration button
#	Then The user shoul se the successfull registration message
#
#Examples: 
#| gender | firstName | lastName | birthDate  | email          | streetAddress     | zipPostalCode | city     | country | phone      | newsletter | password      | confirmPassword |
#| M      | Gordon    | Freeman  | 1989.4.23  | test@test.com  | Baker Street      | 25221         | Sombor   | Serbia  | 0647894563 | Y          | TestPassword  | TestPassword    |
#| M      | Richard   | Nelson   | 1972.9.12  | test2@test.com | Wallker Street    | 21000         | Novi Sad | Serbia  | 063123654  | N          | TestPassword2 | TestPassword2   |
#| F      | Vanesa    | Huston   | 1986.11.25 | test3@test.com | Thompson Bulevard | 10000         | Zagreb   | Croatia | 0713355489 | Y          | TestPassword3 | TestPassword3   |
#|        |           |          |            |                |                   |               |          |         |            |            |               |                 |
#|        |           |          |            |                |                   |               |          |         |            |            |               |                 |
#|        |           |          |            |                |                   |               |          |         |            |            |               |                 |
#|        |           |          |            |                |                   |               |          |         |            |            |               |                 |
#|        |           |          |            |                |                   |               |          |         |            |            |               |                 |
#|        |           |          |            |                |                   |               |          |         |            |            |               |                 |


#Scenario: Register as a private individual client
#	Given The user navigates to the web application Home page
#	#<browser>
#	#| browser |
#	#| chrome  |
#	#| firefox |
#	And The user naviagates to the registration form
#	When The user fills in all the information on the registration form '<gender>', '<firstName>', '<lastName>', '<birthDate>', '<email>', '<streetAddress>', '<zipPostalCode>', '<city>', '<country>', '<phone>', '<newsletter>', '<password>', '<confirmPassword>'
#	| gender | firstName | lastName | birthDate | email         | streetAddress | zipPostalCode | city   | country | phone      | newsletter | password     | confirmPassword |
#	| M      | Gordon    | Freeman  | 1989.4.23 | test@test.com | Baker Street  | 25221         | Sombor | Serbia  | 0647894563 | Y          | TestPassword | TestPassword    |
#	And He clicks on the Submit Registration button
#	Then The user shoul se the successfull registration message


Scenario: Register as a private individual client
	Given The user navigates to the web application Home page
	And The user naviagates to the registration form
	When The user fills in all private individual information on the registration form 'M', 'Gordon', 'Freeman', '1989.4.23', 'test20@test.com', 'Baker Street', '25221', 'Sombor', 'Serbia', '0647894563', 'Y', 'TestPassword', 'TestPassword'
	And He clicks on the Submit Registration button
	Then The user shoul se the successfull registration message


Scenario: Register as a legal entity client
	Given The user navigates to the web application Home page
	And The user naviagates to the registration form
	When The user fills in all legal entity information on the registration form 'M', 'Gordon', 'Freeman', '1989.4.23', 'Baker Street', '25221', 'Sombor', 'Serbia', '0647894563', 'Y', 'TestPassword', 'TestPassword', 'Aperture Science', '12345678910', '1134223112', 'Daren Hopkins', 'Vojvodjanskih Brigada 22', '21 000', 'Novi Sad'
	And He clicks on the Submit Registration button
	Then The user shoul se the successfull registration message