# language: en
Feature: Consulta de CEP e Rastreamento nos Correios

Scenario: Validar CEPs e código de rastreamento inválidos
	Given que eu esteja na página de busca de CEP dos Correios
	When eu pesquisar o CEP "80700000"
	Then devo ver a mensagem de CEP inexistente

	When eu voltar para a página inicial dos Correios
	And eu pesquisar o CEP "01013-001"
	Then devo ver o endereço "Rua Quinze de Novembro, São Paulo/SP"

	When eu voltar para a página inicial dos Correios
	And eu pesquisar o código de rastreamento "SS987654321BR"
	Then devo ver a mensagem de código inválido
