# 🃏 Card Game - Jogo de Cartas Multi-Linguagem
Este projeto é um jogo de cartas que implementa uma arquitetura cliente-servidor para simulação de jogabilidade e persistência de dados. O jogo possui mecânicas simplificadas baseadas em atributos de personagens como Life, Shield e Damage.

## ⚙️ Arquitetura e Tecnologias
O projeto utiliza uma divisão clara de responsabilidades entre as plataformas e tecnologias:

Backend (Servidor): Desenvolvido em Java, gerencia toda a lógica do projeto, regras, usuários, decks e conexões com o banco de dados.

Frontend (Cliente): Desenvolvido em C# para fornecer a interface gráfica (GUI) de interação para o jogador.

Comunicação: A conexão entre o cliente C# e o servidor Java é estabelecida através de TCP Sockets, garantindo uma comunicação confiável e orientada à conexão.

Persistência de Dados: O PostgreSQL é utilizado como banco de dados para armazenar informações de usuários e seus decks pessoais.

na pasta `DB` tem toda a estrutura do banco de dados além do seu script

## 🎮 Funcionalidades Principais
Sistema de Usuário: Gerenciamento de cadastro e login de jogadores.

Decks Pessoais: Cada usuário possui um deck de cartas customizável e persistido.

Modo de Jogo: O jogador enfrenta um Bot (Oponente de IA).

Mecânicas de Combate: O jogo utiliza três atributos básicos para o combate das cartas:

-  Life (Vida): A saúde básica do personagem.

- Shield (Escudo): Proteção que absorve dano enquanto o personagem defende.

- Damage (Dano): O valor de ataque da carta.

Modos de personagens: Os personagens podem ser postos na arena como defensivos(não atacam, mas sofrem dano no shield) ou atacantes(sofrem dano na vida).

Criação de cards: O usuario pode criar sua propria card adicionando uma image, life, damage e shield, em seguida o server gerara um card no modelo padrão do game.
