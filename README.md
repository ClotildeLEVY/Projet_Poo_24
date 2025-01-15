# Projet Programmation orientée objet - M2 TAL 2024
---------------------------------------------------
# 🌱 Le Potager Interactif 🌱

## Présentation du projet 
Ce programme a été conçu pour la gestion ainsi que la simulation d'un potager virtuel.  
L'objectif principal est d'offrir une interface intuitive pour organiser et suivre les avancées de plantations dans un potager. Il s'agit d'un outil qui peut servir à planifier un véritable potager.

⚠️ **REMARQUE :** ⚠️  
Il est important de préciser qu'il s'agit d'un programme fictif. Par conséquent, certains facteurs ne sont pas pris en compte : les saisons _(plantes de saison)_, le climat _(les plantations divergent en fonction de la région géographique)_ ou encore le fait que certaines plantations ne peuvent pas être plantées directement dans un potager _(cf. les arbres fruitiers)_.  
Il s'agit donc d'une simulation de gestion de potager, sans véritable respect des conditions agronomiques ou écologiques.  
Aussi, il n'y a pas de liste de référence incorporée au programme, il est donc impossible de vérifier la validité des plantes ajoutées. J'ai fait l'hypothèse que les utilisateurs entrerons des informations valides. 

## 📊 Les données
Les plantes sont définies selon trois champs obligatoires : 

→ **Nom** : le nom de la plante _(par exemple Piment)_  
→ **Type** : le type de la plante _(Légume, Fruit ou Aromate)_  
→ **Stade** : le stade de la plante :  0 = jeune pousse; 1 = en croissance; 2 = prêt à la récolte

Ces données peuvent être saisies par l'utilisateur lors de l'ajout d'une plante, ou être importées via des fichiers **txt** ou **JSON**.  

## 🔧 Fonctionalités 

Le programme est constitué d'un menu interactif qui permet de guider l'utilisateur. Lorsque l'utilisateur sélectionne une commande _(avec le code correspondant)_, le programme lui demande automatiquement les informations/arguments nécessaires à son bon fontionnement. De cette façon, il ne peut pas y avoir de confusion quant à l'utilisation du programme. 

### Liste des fonctionnalités 

Voici les fonctionnalités offertes à l'utilisateur :  

1. **Ajouter _(planter)_ des plantes au potager** en spécifiant :  
leur nom _(exemple : Piment)_,  
leur type _(exemple : légume)_,  
leur stade de croissance _(exemple : 0)_

2. **Afficher le contenu du potager** :  
Permet d'afficher toutes les plantations présentes dans le potager sous forme de liste ou de grille visuelle _(cf. commande 13)_.  

3. **Classer les plantes présentes au potager selon leur type** :  
Regroupe les plantes du potager en fonction de leur type : légume, fruit ou aromate.  

4. **Arroser les plantes** :  
Augmente le stade de croissance de toutes les plantes présentes dans le potager _(sauf celles déjà prêtes à la récolte, cad celles ayant déjà atteint le stade maximal)_.  

5. **Supprimer/récolter des plantes** :
Retire une plante du potager soit pour la récolter, soit pour la supprimer du potager.  

6. **Rechercher des plantes par leur nom** :  
Permet de vérifier si une plante spécifique se trouve dans le potager en fournissant son **nom**.  

7. **Importer/exporter des données** :  
Charge ou sauvegarde des plantes à partir de fichiers au format **txt** ou **JSON**, nécessite de donner en argument le chemin vers le fichier à sauvegarder ou à charger. 

8. **Afficher les plantes prêtes à être récoltées** :  
Liste uniquement les plantes ayant atteint le stade final _(le stade 2)_.  

## 🔍 Exemples d'utilisation  
Voici quelques exemples d'utilisation à titre indicatif.  

### AJOUTER UNE PLANTE  
- taper `1` dans le menu principal
- le programme demandera d'entrer le **nom** de la plante : _Piment_, le **type** : _Légume_ et le **stade** : _0_  
- un message indiquera que la plante a bien été ajoutée au potager ou non si les arguments ne sont pas valides _(si le type et/ou le stade de croissance sont incorrects)_.  

### ARROSER LES PLANTES DU POTAGER
- taper `5` dans le menu principal  
- toutes les plantes du potager seront arrosées et passeront au stade supérieur  
- un message affichera les plantes arrosées ainsi que leur nouveau stade _(après arrosage)_

### AFFICHER LE POTAGER  
Il y a deux manières d'afficher le contenu du potager : sous forme de liste et sous forme de grille visuelle.  
Pour la liste :  
- taper `2` dans le menu principal  
- le programme affichera la liste des plantes présentes au potager  

Pour la grille : 
- taper `13` dans le menu principal  
- le programme affichera le potager visuellement sous forme de grille constituée des plantes présentes au potager ainsi que les espaces vides _(puisque le potager est limité à 9 places)_  

### IMPORTER/EXPORTER DES DONNÉES  
- taper `8` ou `10` _(en foncion du format txt csv ou Json)_ dans le menu principal  
- le programme demandera à l'utilisateur d'entrer le chemin complet du fichier à charger  
- le programme chargera les données _(si valides)_ dans le potager en fonction des différentes contraintres liées notamment à la place limitée  

- taper `9` ou `11`  _(en foncion du format txt csv ou Json)_ pour sauvegarder les données du potager actuel dans un fichier  
- le programme demandera à l'utilisateur d'entrer le chemin complet pour sauvegarder les fichier  
- le programme enregistrera les données dans le fichier souhaité  
