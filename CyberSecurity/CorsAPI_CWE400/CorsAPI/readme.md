# CWE-400 : Uncontrolled Resource Consumption

Aussi comparable à une attaque DDOS, l'idée de cette faille est de multiplier les appels à un service dans un laps de temps très court afin d'exploser le montant de ressource utilisée, jusqu'à arriver jusqu'à un déni de service.

Pour les composants web, il est donc important de mettre des mécanismes afin de rejeter ces appels, et limiter au maximum le risque de faire tomber le service.

Ce genre de mécanisme doit être utilisé en addition à des sécurités sur vos infrastructure interne.

# Documentation

* [CWE-400: Uncontrolled Resource Consumption - cwe.mitre.org](https://cwe.mitre.org/data/definitions/400.html)