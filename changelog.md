# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0-preview.4](https://github.com/unity-game-framework/ugf-models/releases/tag/3.0.0-preview.4) - 2024-05-29  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/17?closed=1)  
    

### Removed

- Remove model combined enumerable support ([#52](https://github.com/unity-game-framework/ugf-models/issues/52))  
    - Update dependencies: `com.ugf.editortools` to `3.0.0-preview.9` version.
    - Remove `ModelCombined` class enumerable implementation.

## [3.0.0-preview.3](https://github.com/unity-game-framework/ugf-models/releases/tag/3.0.0-preview.3) - 2024-02-19  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/16?closed=1)  
    

### Added

- Add clone support ([#50](https://github.com/unity-game-framework/ugf-models/issues/50))  
    - Add `IModelCloneable` interface used to implement model with clone support.
    - Add `ModelUtility` static class with `CreateCopy<T>()` method as model copy shortcut.
    - Change `ModelCombined`, `CollectionDictionaryModel<T>`, `CollectionListModel<T>` and `DomainModel` models to support `IModelCloneable` interface.

## [3.0.0-preview.2](https://github.com/unity-game-framework/ugf-models/releases/tag/3.0.0-preview.2) - 2024-01-28  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/15?closed=1)  
    

### Added

- Add combined model ([#48](https://github.com/unity-game-framework/ugf-models/issues/48))  
    - Update dependencies: `com.ugf.editortools` to `3.0.0-preview.2` and `com.ugf.assets` to `1.0.0-preview.2` versions.
    - Add `ModelCombined` class as copyable and clearable model implementation with a collection of nested models.

## [3.0.0-preview.1](https://github.com/unity-game-framework/ugf-models/releases/tag/3.0.0-preview.1) - 2023-11-30  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/14?closed=1)  
    

### Fixed

- Fix domain model class missing interface implementation ([#46](https://github.com/unity-game-framework/ugf-models/issues/46))  
    - Fix `DomainModel` class missing `IDomainModel` interface implementation.

## [3.0.0-preview](https://github.com/unity-game-framework/ugf-models/releases/tag/3.0.0-preview) - 2023-11-23  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/13?closed=1)  
    

### Added

- Add copyable and clearable interfaces ([#42](https://github.com/unity-game-framework/ugf-models/issues/42))  
    - Add `IModelClearable` interface used to implement model clear method.
    - Add `IModelCopyable` interface used to implement model copy method.
    - Add `CollectionDictionaryModel` and `CollectionListModel` classes clear and copy interface support.
    - Add `DomainModel`, `DomainModelCollectionModel` and `DomainModelGroupModel` classes clear and copy support.
- Add model collection folder ([#39](https://github.com/unity-game-framework/ugf-models/issues/39))  
    - Update dependencies: add `com.ugf.assets` of `1.0.0-preview` version.
    - Add `CollectionDictionaryModelFolderAsset`, `CollectionListModelFolderAsset` and `ModelFolderAsset` classes as implementation of asset folders.

### Removed

- Remove domain model collection asset ([#41](https://github.com/unity-game-framework/ugf-models/issues/41))  
    - Remove `DomainModelCollectionAsset` and related classes.
- Remove controllers and systems ([#38](https://github.com/unity-game-framework/ugf-models/issues/38))  
    - Update dependencies: remove `com.ugf.module.controllers` package.
    - Update package _Unity_ version to `2023.2`.
    - Update package registry to _UPM Hub_.
    - Remove `DomainSystemModel` and related classes.
    - Remove `ModelController` and related classes.

## [2.0.0-preview.10](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.10) - 2023-06-05  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/12?closed=1)  
    

### Changed

- Change collection count property to method ([#35](https://github.com/unity-game-framework/ugf-models/issues/35))  
    - Change `ICollectionModel.Count` property to `GetCount()` method.

## [2.0.0-preview.9](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.9) - 2023-05-22  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/11?closed=1)  
    

### Added

- Add collection capacity constructor ([#33](https://github.com/unity-game-framework/ugf-models/issues/33))  
    - Add `CollectionDictionaryModel<T>` and `CollectionListModel<T>` classes constructor with parameter as collection capacity.

## [2.0.0-preview.8](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.8) - 2023-05-16  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/10?closed=1)  
    

### Added

- Add collection clear method override ([#31](https://github.com/unity-game-framework/ugf-models/issues/31))  
    - Add `CollectionDictionaryModel.OnClear()` and `CollectionListModel.OnClear()` protected virtual methods which can be used to add additional clear logic.

## [2.0.0-preview.7](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.7) - 2023-05-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/9?closed=1)  
    

### Added

- Add model collection asset ([#29](https://github.com/unity-game-framework/ugf-models/issues/29))  
    - Add `ModelCollectionAsset` abstract class as asset collection of models.
    - Add `ModelCollectionListAsset` class as default implementation of the model collection.
    - Add `DomainModelAsset.ModelCollections` property as collections of models.
- Add generic model asset ([#25](https://github.com/unity-game-framework/ugf-models/issues/25))  
    - Add `ModelAsset<T>` generic class.

### Changed

- Remove class constraint for model collections ([#24](https://github.com/unity-game-framework/ugf-models/issues/24))  
    - Add `ICollectionModel` interface and implementation for `CollectionDictionaryModelAsset` and `CollectionListModel` classes.
    - Remove `CollectionDictionaryModelAsset` and `CollectionListModel` generic class constraint for `TModel`.

## [2.0.0-preview.6](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.6) - 2023-01-05  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/8?closed=1)  
    

### Changed

- Update dependencies ([#20](https://github.com/unity-game-framework/ugf-models/issues/20))  
    - Update dependencies: `com.ugf.module.controllers` to `4.0.0` and `com.ugf.editortools` to `2.15.0` versions.
    - Update package _Unity_ version to `2022.2`.

## [2.0.0-preview.5](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.5) - 2022-12-09  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/7?closed=1)  
    

### Fixed

- Fix collection editors ([#17](https://github.com/unity-game-framework/ugf-models/issues/17))  
    - Fix `CollectionDictionaryModelAsset` and `CollectionListModelAsset` classes display in editor when inherited from the generic base type.

## [2.0.0-preview.4](https://github.com/unity-game-framework/ugf-models/releases/tag/2.0.0-preview.4) - 2022-12-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-models/milestone/6?closed=1)  
    

### Changed

- Change model collections ([#14](https://github.com/unity-game-framework/ugf-models/issues/14))  
    - Add `CollectionDictionaryModelController` and `CollectionListModelController` classes to work with model collection changes.
    - Add `DomainModelGroupModelController` class to work with group model changes.
    - Change `CollectionDictionaryModel` and `CollectionListModel` model classes to defined as generic with model instances instead of ids.
    - Change `DomainSystemModelController` and `DomainModelController` classes to support model changes.
- Change domain model collection model ([#13](https://github.com/unity-game-framework/ugf-models/issues/13))  
    - Update dependencies: `com.ugf.editortools` to `2.14.0` version.
    - Add `DomainModelCollectionListAsset` class support of nested collections and model build.
    - Change `DomainModelCollectionAsset` class to be a model asset.
    - Change `DomainModelAsset.Collections` property to be defined as collection of asset references.

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


