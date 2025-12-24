# 🚀 Desafio Técnico – Genesis Consulting & B3

Este repositório contém o código desenvolvido como parte de um **desafio técnico proposto pela Genesis Consulting em parceria com a B3**.

O projeto tem como objetivo demonstrar conhecimentos em **automação de testes**, utilizando **C# com Playwright**.

---

## 🧪 Escopo do Projeto

Foram automatizados testes em duas plataformas distintas:

- 📦 **Correios**
- 🎵 **Parodify**

Cada plataforma possui particularidades que foram consideradas durante o desenvolvimento dos testes.

---

## ⚠️ Atenção: CAPTCHA no site dos Correios

O site dos **Correios** utiliza **CAPTCHA**, o que impede a automação completa do fluxo de testes.

Por esse motivo, foi adotada uma abordagem **semi-automatizada**, exigindo **interação humana** nesse ponto específico.

### 🔍 Como o teste lida com o CAPTCHA

- O teste aguarda o usuário **iniciar a digitação** no campo do CAPTCHA
- Ao detectar a digitação, inicia-se uma **contagem regressiva de 15 segundos**
- Durante esse período:
  - ⏳ O teste permanece pausado
  - ✍️ O usuário deve concluir o preenchimento do CAPTCHA
- Após o término do tempo, o fluxo automatizado é retomado automaticamente

> ℹ️ Essa solução respeita as restrições de segurança do site e permite a continuidade do teste.
