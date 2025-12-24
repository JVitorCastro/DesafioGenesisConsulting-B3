🧪 Desafio Técnico – Genesis Consulting & B3

Este repositório contém o código desenvolvido como parte de um desafio técnico proposto pela Genesis Consulting em parceria com a B3.

O objetivo do projeto é a automação de testes em duas plataformas distintas, utilizando C# com Playwright.

🌐 Plataformas Testadas

Os testes automatizados contemplam as seguintes aplicações:

Correios

Parodify

⚠️ Observação Importante sobre o Site dos Correios

O site dos Correios possui um CAPTCHA, o que impede a automação completa do fluxo.

Por esse motivo, o teste foi projetado para exigir interação humana nesse ponto específico.

🧩 Funcionamento do CAPTCHA no teste

Ao chegar na etapa do CAPTCHA, o teste:

Aguarda o usuário iniciar a digitação no campo do CAPTCHA

Após detectar a digitação, inicia uma contagem de 15 segundos

Esse tempo é destinado para que o usuário conclua o preenchimento do CAPTCHA

Enquanto a contagem não finalizar, o teste permanece pausado

Após os 15 segundos, o fluxo automatizado é retomado automaticamente

ℹ️ Essa abordagem garante que o teste possa prosseguir sem violar as restrições impostas pelo CAPTCHA.

📌 Observações Finais

O projeto foi desenvolvido exclusivamente para fins de avaliação técnica

O uso de interação humana no CAPTCHA é intencional e necessário

Não há qualquer tentativa de burlar mecanismos de segurança das aplicações testadas
