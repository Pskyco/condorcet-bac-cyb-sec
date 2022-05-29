# Configuration des CORS

La configuration des CORS s'effectue dans le ``Startup.cs``.

Définisez vos différentes ``policies`` et définisez laquelle vous souhaitez utiliser grâce à ``app.UseCors("MyPolicy")``
ou via l'attribut ``EnableCors`` placé sur vos controllers.

L'attribut ``DisableCors`` permet quant à lui de désactiver ponctuellement les CORS sur un endpoint.

La configuration des CORS est importante pour restreindre l'accès à votre application, si des opérations spécifiques ne
peuvent s'opérer que depuis certaines origines.

# Démonstration

* Lancer le projet 'WebApplication' et cliquez sur le bouton 'CORS Security'
* Les résultats de la requête s'afficheront dans le bandeau vert.
* Les erreurs (s'il y a) s'afficheront dans le bandeau rouge, et l'application vous invitera à ouvrir votre console pour
  les observer.
* Cliquez sur les différents boutons pour tester votre configuration.
* Par défaut, l'application ``CorsAPI`` n'autorise que les requêtes venant de cette application MVC.
* Le dernier bouton, quant à lui, est décoré avec l'attribut ``DisableCors``, il ne réponds donc pas à la même policy.

## Documentation

* [CORS documentation - developer.mozilla.org](https://developer.mozilla.org/fr/docs/Web/HTTP/CORS)