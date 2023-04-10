Feature: SpecFlowYandexUnitTests
	In order to find emails
	As a Yandex user
	I want to be able to navigate to folders in yandex mail

Background:
	Given I log in to yandex mail box

@smoke
Scenario: The actual user name after login should match the entered login
	When I get the actual user name from User Account option
	Then the actual user name should match the entered login

@smoke
Scenario Outline: The created draft email should present in the Drafts folder
	When I create an email with '<subject>' and '<body>'
	And I save the created email to Drafts folder
	And I navigate to Drafts folder
	And get the actual subject
	Then the email with '<subject>' should present in the folder

	Examples:
		| subject        | body                               |
		| Test Selenium  | Test Selenium from Kate            |
		| Test Selenium2 | Test Selenium from Kate the second |

@smoke
Scenario Outline: The actual Addressee, Subject and Body of the created draft email should match the entered
	When I create an email with '<subject>' and '<body>'
	And I save the created email to Drafts folder
	And I navigate to Drafts folder
	And get the actual addressee
	And get the actual subject
	And get the actual body
	Then the actual addresse, the '<subject>' and the '<body>' from the draft email should match the entered

		Examples:
		| subject        | body                    |
		| Test Selenium  | Test Selenium from Kate |

@smoke
Scenario Outline: The sent newly created email should present in the Sent folder
	When I create an email with '<subject>' and '<body>'
	And I send the created email
	And I navigate to the Sent folder
	And get the actual subject
	Then the email with '<subject>' should present in the folder

	Examples:
		| subject        | body                    |
		| Test Selenium  | Test Selenium from Kate |

@smoke
Scenario Outline: The sent draft email should present in the Sent folder
	When I create an email with '<subject>' and '<body>'
	And I save the created email to Drafts folder
	And I navigate to Drafts folder
	And I send draft email
	And I navigate to the Sent folder
	And get the actual subject
	Then the email with '<subject>' should present in the folder

	Examples:
		| subject       | body                    |
		| Test Selenium | Test Selenium from Kate |

@smoke
Scenario Outline: The sent newly created email should not present in the Drafts folder
	When I create an email with '<subject>' and '<body>'
	And I send the created email
	And I navigate to Drafts folder
	And get the actual draft info message
	Then the actual draft info message should match the expected

	Examples:
		| subject       | body                    |
		| Test Selenium | Test Selenium from Kate |

@smoke
Scenario Outline: The sent newly created email should not present in the Trash folder
	When I create an email with '<subject>' and '<body>'
	And I send the created email
	And I navigate to Trash folder
	And get the actual trash info message
	Then the actual trash info message should match the expected

	Examples:
		| subject       | body                    |
		| Test Selenium | Test Selenium from Kate |

@smoke
Scenario Outline: The deleted draft email should present in the Trash folder
	When I create an email with '<subject>' and '<body>'
	And I save the created email to Drafts folder
	And I navigate to Drafts folder
	And I move the draft email to Trash folder
	And I navigate to Trash folder
	And get the actual subject
	Then the email with '<subject>' should present in the folder

	Examples:
		| subject       | body                    |
		| Test Selenium | Test Selenium from Kate |

@smoke
Scenario Outline: The deleted draft email should not present in the Drafts folder
	When I create an email with '<subject>' and '<body>'
	And I save the created email to Drafts folder
	And I navigate to Drafts folder
	And I delete all emails
	And get the actual draft info message
	Then the actual draft info message should match the expected

	Examples:
		| subject       | body                    |
		| Test Selenium | Test Selenium from Kate |

@smoke
Scenario Outline: The deleted email should not present in the Trash folder
	When I create an email with '<subject>' and '<body>'
	And I save the created email to Drafts folder
	And I navigate to Drafts folder
	And I delete all emails
	And I navigate to Trash folder
	And I delete all emails
	And get the actual trash info message
	Then the actual trash info message should match the expected

	Examples:
		| subject       | body                    |
		| Test Selenium | Test Selenium from Kate |

@smoke
Scenario: The logout title should be diplayed on the Logout page
	When I navigate to Logout page
	And I get the actual title from Logout page
	Then the expected logout title should be displayed