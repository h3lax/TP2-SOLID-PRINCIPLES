En préambule je tiens à signaler que j'ai passé beaucoup BEAUCOUP de temps sur ces exercices, c'était très intéressant mais calibrage à revoir un peu peut être
J'ai réalisé chaque Exercice dans des commits dédiés pour que ce soit facile de comprendre ce qui a été fait à chaque étape, j'invite donc à regarder les commits pour chaque exercice pour comprendre rapidement les modifications.

### SRP — Single Responsibility Principle

Chaque couche ne doit avoir qu'une responsabilité, c'est ce qu'on a fait en restructurant complètement l'application en 3 couches : Domain, Application et Infrastructure. De la même manière, chaque rôle user doit pouvoir accéder uniquement aux méthodes qu'elle nécéssite. C'est ce qu'on a fait en sortant des fonctions du Modèle Reservation et en les ajoutant dans des services Domain spécifiques. Pareil pour les services transverses comme le reservationService qu'on a séparé pour qu'on puisse identifier L'app qui orchestre, le Domaine qui gère les règles métier et l'Infrastructure qui est indépendante et peut connecter une DB ou simplement des mocks sans que les autres couches s'en rendent compte.

### OCP — Open/Closed Principle

Ici, on a fait attention au classes et Interfaces qui une fois écrites doivent pouvoir évoluer avec l'utilisation de l'application (au sens général) donc avec l'évolution des règles métier. Il s'agit donc de bien comprendre quel est l'utilisation d'une interface spécifique et d'utiliser un design patern approprié. C'est ce qu'on a fait avec le Strategy pattern où qui nous permet d'ajouter des CancellationsPolicies en fonction de nos besoins. On a aussi fait un petit resolver pour retrouver la bonne policy en fonction de son label afin de conserver le code du programe existant inchangé.

### LSP — Liskov Substitution Principle 

Ici c'est un peu plus subtile. Concrètement, on s'est rendu compte que même en appliquant certaines interfaces, les implémentations peuvent ne pas correspondre au comportement attendu par le design initial de l'interface. Avec ICancellable on avait une implémentation qui forçait une erreur à l'utilisation d'une méthode requise, ce qui est très bizarre (personne ne fait ça mais bon). Quand à CachedRoomRepository on avait bien l'implémentation de la méthode de Listing de Room mais elle n'utilisait pas les paramètres qu'elle demandait en paramètres. Bref, globalement nous avons fait attention à implémenter plus précisément les interfaces quitte à en recréer de nouvelles. comme avec Ireservation > ICancellableReservation

### ISP — Interface Segregation Principle

On avait ici une interface unique qui donnait accès à toutes les fonctionnalité du IReservationRepository à tout ceux qui en avaient besoin. C'était problématique en terme de Sécurité (des acteurs tiers qui ne devraient que lire pouvaient modifier le code potentiellment) On a donc séparé les responsabilités accordées par l'interface en fonction des utilisateurs. Accordant ainsi plus ou moins de droits aux services associés. Par exemple l'interface spécifique à la compta, IReservationFinancials n'a besoin que des fonctions de calculs sur les résa etc ... De la même manière, on a aussi Interfacé des Models avec IInvoiceData pour restreindre l'usage des objets Reservation concernés dans les services qui les utilisaient. Ces derniers n'ont donc plus accès qu'à ce qu'ils ont besoin. + de sécurité moins de bugs.

### DIP — Dependency Inversion Principle

On a fait attention ici à la hiérarchie des différentes couches applicative. Cela était d'autant plus facile que nous avions déjà fait le gros du travail de rangement au début. Globalement l'idée est de conserver Infrastructure > Application > Domain, les derniers ne peuvent voir ce qui se passe en amont. C'est pour ça qu'on a fait un DépendancyInjector pour que les services dans notre couche applicative ne se préoccupent pas des éléments d'infrastructure qu'ils consomment. On a aussi fait attention à placer les interface du coté des consommateurs. Et enfin quand c'est un peu trop tricky on a utilisé un adapteur pour résoudre les besoin des interfaces métier avec les méthodes spécifique de l'infrastructure. 