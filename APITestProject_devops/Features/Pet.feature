Feature: Pet

A short summary of the feature

@tag1
Scenario Outline: Get pet by status validation
	Given I set base url
	When I send request to get pet by status <status>
	Then Response status should be 200
	And  <name> should be include

Examples: 
| status    | name   |
| available | doggie |
| pending   | Kitty  |