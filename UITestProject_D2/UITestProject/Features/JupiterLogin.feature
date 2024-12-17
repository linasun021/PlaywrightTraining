Feature: JupiterLogin
In order to manage account and purchases
As a user
I want to be able to login


@smoke @dev @test @sit
Scenario Outline: Login - inviad user
	Given Home page has been load 
	When I login via user <user>
	Then User should see the incorrect login error message

Examples: 
| user   |
| User01 |
| User02 |
