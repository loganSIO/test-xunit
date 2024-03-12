# Séance 2 - La reprise d'un projet Legacy

## I - Les difficultés liées à la validation

### Violations des principes SOLID :

1.  **Violation du principe SRP (Single Responsibility Principle)** :

  - Les classes `Morpion` et `PuissanceQuatre` ont des méthodes qui gèrent à la
  fois l'interface utilisateur, la logique du jeu et la gestion de l'état du
  jeu. Cela les rend difficilement extensibles et maintenables, car elles ont
  trop de responsabilités, ce n'est pas très modulaire.

2.  **Violation du principe OCP (Open/Closed Principle)** :

  - Les méthodes de manipulation du plateau (`tourJoueur`, `tourJoueur2`,
  `verifVictoire`, `verifEgalite`, etc.) contiennent des parties de logique
  spécifique à chaque jeu. Cela rend difficile l'extension du logiciel pour
  supporter d'autres jeux sans modification du code existant.

3.  **Violation du principe LSP (Liskov Substitution Principle)** :

  - Il n'y a pas de hiérarchie claire de classes pour représenter différents
  types de jeux, ce qui pourrait rendre difficile l'ajout de nouveaux jeux tout
  en maintenant la compatibilité avec le reste du code.

4.  **Violation du principe ISP (Interface Segregation Principle)** :

  - Les classes Morpion et PuissanceQuatre implémentent un ensemble complet de fonctionnalités sans découpage clair des interfaces en fonctionnalités spécifiques.

5.  **Violation du principe DIP (Dependency Inversion Principle)** :

  - Les classes Program, Morpion, et PuissanceQuatre implémentent des dépendances directes entre elles, sans utiliser d'abstractions. Cela rend le code plus rigide et moins flexible aux changements.

### Code Smells :

1.  **Duplicated code** :

  - Les méthodes `tourJoueur` et `tourJoueur2` dans les classes `Morpion` et
  `PuissanceQuatre` contiennent un code très similaire. Il serait judicieux de
  factoriser ce code commun pour éviter la duplication.

2.  **BLOB** :

  - Les classes Morpion et PuissanceQuatre contiennent une grande quantité de
  fonctionnalités et de responsabilités (200 à 300 lignes), ce qui les rend
  difficiles à maintenir, à comprendre et à modifier.

3.  **Long Method** :

  -  Les méthodes tourJoueur et tourJoueur2 dans les classes Morpion et PuissanceQuatre contiennent une quantité excessive d'instructions et de logique, ce qui rend leur compréhension et leur maintenance difficile.

4.  **Large Class** :

  -  Présence de nombreuses méthodes et variables dans les classes Morpion et PuissanceQuatre, ce qui peut compliquer la maintenance et l'évolutivité du code.

5.  **Large Switch statement** :

-  Le code contient de grands blocs switch, ce qui peut rendre le code difficile à maintenir et à étendre.

6.  **Shotgun surgery** :

-  Le code actuel présente un risque de "shotgun surgery", où des modifications mineures pourraient nécessiter des ajustements dispersés dans plusieurs parties du code.

7.  **Code mort** :

-  Le code contient du code mort, notamment dans `PuissanceQuatre` à l'intérieur du switch

### La cohésion du code:

Le code présente une faible cohésion car les méthodes dans les classes `Morpion` et `PuissanceQuatre` effectuent plusieurs tâches différentes, telles que la manipulation de la grille de jeu, la gestion des entrées utilisateur et la vérification des conditions de victoire ou d'égalité. Ces tâches ne sont pas étroitement liées ou regroupées autour d'une seule fonctionnalité ou d'une seule responsabilité, ce qui entraîne une dispersion du code et une complexité accrue. En conséquence, la logique du programme devient moins claire et la maintenance du code peut devenir plus difficile.

### Couplage du code:

Le code présente un couplage relativement fort, car les différentes parties du code interagissent étroitement entre elles, notamment à travers les méthodes qui manipulent directement la grille de jeu et gèrent les entrées utilisateur. Cela rend le code plus interdépendant et moins modulaire, ce qui peut rendre les modifications et les extensions plus difficiles à réaliser sans affecter d'autres parties du système.

## II - Les méthodes de résolution de ces problèmes

### Validation de l'existant et résolution des problèmes

#### Violations des principes SOLID :

-   **SRP (Single Responsibility Principle)** : Diviser les classes Morpion et PuissanceQuatre en classes distinctes pour l'interface utilisateur, la logique du jeu et la gestion de l'état du jeu pour améliorer la modularité et la maintenabilité.

-   **OCP (Open/Closed Principle)** : Utiliser des interfaces ou des classes abstraites pour définir des contrats génériques pour les différentes parties du jeu afin de faciliter l'extension du logiciel pour supporter d'autres jeux sans modification du code existant.

-   **LSP (Liskov Substitution Principle)** : Mettre en place une hiérarchie claire de classes pour représenter différents types de jeux, facilitant ainsi l'ajout de nouveaux jeux tout en maintenant la compatibilité avec le reste du code.

-   **ISP (Interface Segregation Principle)** : Diviser les interfaces en fonctionnalités spécifiques pour réduire les dépendances et rendre le code plus flexible aux changements.

-   **DIP (Dependency Inversion Principle)** : Utiliser des abstractions et des injections de dépendances pour rendre le code plus flexible et moins couplé.

#### Code Smells :

-   **Code dupliqué** : Supprimer les codes dupliqués en factorisant le code commun dans des méthodes réutilisables.

-   **BLOB (Big Lumps of code)** : Réduire la taille des classes en décomposant les méthodes longues en plusieurs méthodes plus petites et plus spécifiques.

-   **Switch statements** : Éviter les grands blocs switch en utilisant des structures de données appropriées.

-   **Code mort** : Supprimer le code inutilisé pour maintenir la lisibilité du code.

#### Cohésion et couplage du code :

-   **Cohésion du code** : Regrouper les méthodes étroitement liées autour d'une seule fonctionnalité ou d'une seule responsabilité.

-   **Couplage du code** : Limiter les interactions directes entre les différentes parties du code en utilisant des interfaces et des abstractions pour définir des contrats clairs.

En suivant ces méthodes, vous pourrez améliorer la qualité du code, réduire la complexité et faciliter la maintenance et l'évolutivité de votre application.

#### Tests à réaliser :

1.  Test unitaire pour chaque méthode publique afin de vérifier son comportement attendu.

2.  Tests d'intégration pour vérifier que les différentes parties du jeu interagissent correctement les unes avec les autres.

3.  Tests fonctionnels pour valider le comportement global du jeu en simulant des interactions utilisateur.

## III - Le développement des fonctionnalités manquantes

Pour l'instant, je n'ai pas eu l'opportunité de mettre en place les fonctionnalités manquantes en raison de contraintes de temps. Cependant, j'ai entrepris une veille active en consultant le repository github de mes collègues pour rester informé sur les avancées et les meilleures pratiques concernant ces fonctionnalités.