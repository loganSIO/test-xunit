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

## III - Le développement des fonctionnalités manquantes