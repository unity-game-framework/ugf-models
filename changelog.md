# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0-preview.3](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.3) - 2022-11-12  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/5?closed=1)  
    

### Added

- Add collection models ([#11](https://github.com/unity-game-framework/ugf-models/issues/11))  
    - Add `CollectionListModel` and related classes as model with item ids stored as list.
    - Add `CollectionDictionaryModel` and related classes as model with item ids stored as dictionary.

## [2.0.0-preview.2](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.2) - 2022-11-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/4?closed=1)  
    

### Added

- Add domain model collection model ([#8](https://github.com/unity-game-framework/ugf-models/issues/8))  
    - Update dependencies: `com.ugf.module.controllers` to `4.0.0-preview.6` version.
    - Add `DomainModelCollectionModel` and related classes as collection of models defined at the domain.
    - Add `DomainModelAsset` and `DomainModelCollectionListAsset` collections replacement support in inspector.
    - Fix `DomainModelCollectionListAsset` class create menu order.
- Add domain model group ([#7](https://github.com/unity-game-framework/ugf-models/issues/7))  
    - Add `DomainModelGroupModel` and related classes to define model relations.

## [2.0.0-preview.1](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.1) - 2022-10-29  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/3?closed=1)  
    

### Added

- Add domain model collections ([#5](https://github.com/unity-game-framework/ugf-models/issues/5))  
    - Add `DomainModelCollectionAsset` abstract class to implement domain models collection.
    - Add `DomainModelCollectionListAsset` class as implementation of domain model collection using list.
    - Add `DomainModelAsset.Collections` property as list of `DomainModelCollectionAsset` collections used to setup domain model.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview) - 2022-10-22  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/2?closed=1)  
    

### Changed

- Update project ([#3](https://github.com/unity-game-framework/ugf-models/issues/3))  
    - Update dependencies: `com.ugf.module.controllers` to `4.0.0-preview.3` version.
    - Update package _Unity_ version to `2022.1`.
    - Change `IDomainModel` and related classes to use structure id instead of strings.
    - Remove `DomainModelMeta` class.
    - Remove `DomainModelExecuteController` and `DomainModelOperatorController` controller classes.
    - Remove `DomainSystemModelOperatorController` and `DomainSystemModelProviderController` controller classes.

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-models/releases/tag/1.0.0-preview.1) - 2022-02-11  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/1?closed=1)  
    

### Added

- Add IDomainModelOperatorController try get id method ([#1](https://github.com/unity-game-framework/ugf-models/issues/1))  
    - Update dependencies: `com.ugf.module.controllers` to `2.1.1` version.
    - Add `IDomainModelOperatorController.TryGetId()` method to get id of model object.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-models/releases/tag/1.0.0-preview) - 2021-12-30  

### Release Notes

- No release notes.


