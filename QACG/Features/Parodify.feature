# language: en
Feature: Consulta de Músicas no Parodify

Scenario: Validar pesquisa de músicas válidas e inválidas
	Given que eu esteja na página inicial do Parodify
	When eu pesquisar a música "Lithium"
	Then nenhuma música deve ficar vísivel
	And deve exibir a mensagem: "Desculpe, não encontramos nenhuma música com termo informado."

	When eu voltar para a página inicial
	And eu pesquisar a música "All The Small Sprints"
	Then devo ver apenas a música "All The Small Sprints" sendo exibida

	When eu voltar para a página inicial
	And eu pesquisar a música "Smells Like Teen Spirit"
	Then nenhuma música deve ficar vísivel
	And deve exibir a mensagem: "Desculpe, não encontramos nenhuma música com termo informado."