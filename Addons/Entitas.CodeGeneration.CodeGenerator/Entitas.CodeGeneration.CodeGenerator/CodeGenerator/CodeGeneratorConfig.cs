using System;
using System.Linq;
using Entitas.Utils;

namespace Entitas.CodeGeneration.CodeGenerator {

    public class CodeGeneratorConfig {

        public static readonly string[] keys = {
            PROJECT_PATH_KEY,
            SEARCH_PATHS_KEY,
            ASSEMBLY_PATHS_KEY,
            PLUGINS_PATHS_KEY,
            DATA_PROVIDERS_KEY,
            CODE_GENERATORS_KEY,
            POST_PROCESSORS_KEY,
            TARGET_DIRECTORY_KEY,
            CONTEXTS_KEY
        };

        public const string PROJECT_PATH_KEY = "Entitas.CodeGeneration.Project";
        const string DEFAULT_PROJECT_PATH = "Assembly-CSharp.csproj";
        public string projectPath { 
            get { return _config.GetValueOrDefault(PROJECT_PATH_KEY, DEFAULT_PROJECT_PATH); }
            set { _config[PROJECT_PATH_KEY] = value; }
        }

        public const string SEARCH_PATHS_KEY = "Entitas.CodeGeneration.SearchPaths";
        const string SEARCH_PATHS = "Libraries/Entitas, Libraries/Entitas/Editor, /Applications/Unity/Unity.app/Contents/Managed, /Applications/Unity/Unity.app/Contents/Mono/lib/mono/unity";
        public string[] searchPaths { 
            get { return separateValues(_config.GetValueOrDefault(SEARCH_PATHS_KEY, SEARCH_PATHS)); }
            set { _config[SEARCH_PATHS_KEY] = joinValues(value); }
        }

        public const string ASSEMBLY_PATHS_KEY = "Entitas.CodeGeneration.Assemblies";
        const string DEFAULT_ASSEMBLY_PATHS = "Library/ScriptAssemblies/Assembly-CSharp.dll";
        public string[] assemblies { 
            get { return separateValues(_config.GetValueOrDefault(ASSEMBLY_PATHS_KEY, DEFAULT_ASSEMBLY_PATHS)); }
            set { _config[ASSEMBLY_PATHS_KEY] = joinValues(value); }
        }

        public const string PLUGINS_PATHS_KEY = "Entitas.CodeGeneration.Plugins";
        const string PLUGINS_PATHS = "Entitas.CodeGeneration.Plugins, Entitas.VisualDebugging.CodeGeneration.Plugins, Entitas.Blueprints.CodeGeneration.Plugins";
        public string[] plugins { 
            get { return separateValues(_config.GetValueOrDefault(PLUGINS_PATHS_KEY, PLUGINS_PATHS)); }
            set { _config[PLUGINS_PATHS_KEY] = joinValues(value); }
        }

        public const string DATA_PROVIDERS_KEY = "Entitas.CodeGeneration.DataProviders";
        public string[] dataProviders {
            get {  return separateValues(_config.GetValueOrDefault(DATA_PROVIDERS_KEY, _defaultDataProviders)); }
            set { _config[DATA_PROVIDERS_KEY] = joinValues(value); }
        }

        public const string CODE_GENERATORS_KEY = "Entitas.CodeGeneration.CodeGenerators";
        public string[] codeGenerators {
            get {  return separateValues(_config.GetValueOrDefault(CODE_GENERATORS_KEY, _defaultCodeGenerators)); }
            set { _config[CODE_GENERATORS_KEY] = joinValues(value); }
        }

        public const string POST_PROCESSORS_KEY = "Entitas.CodeGeneration.PostProcessors";
        public string[] postProcessors {
            get {  return separateValues(_config.GetValueOrDefault(POST_PROCESSORS_KEY, _defaultPostProcessors)); }
            set { _config[POST_PROCESSORS_KEY] = joinValues(value); }
        }

        public const string TARGET_DIRECTORY_KEY = "Entitas.CodeGeneration.TargetDirectory";
        const string DEFAULT_TARGET_DIRECTORY = "Assets/Generated";
        public string targetDirectory { 
            get { return _config.GetValueOrDefault(TARGET_DIRECTORY_KEY, DEFAULT_TARGET_DIRECTORY); }
            set { _config[TARGET_DIRECTORY_KEY] = value; }
        }

        public const string CONTEXTS_KEY = "Entitas.CodeGeneration.Contexts";
        const string DEFAULT_CONTEXTS = "Game, GameState, Input";
        public string[] contexts {
            get { return separateValues(_config.GetValueOrDefault(CONTEXTS_KEY, DEFAULT_CONTEXTS)); }
            set { _config[CONTEXTS_KEY] = joinValues(value); }
        }

        readonly Config _config;

        readonly string _defaultDataProviders;
        readonly string _defaultCodeGenerators;
        readonly string _defaultPostProcessors;

        public CodeGeneratorConfig(Config config) : this(config, new string[0], new string[0], new string[0]) {
        }

        public CodeGeneratorConfig(Config config, string[] dataProviders, string[] codeGenerators, string[] postProcessors) {
            _config = config;
            _defaultDataProviders = joinValues(dataProviders);
            _defaultCodeGenerators = joinValues(codeGenerators);
            _defaultPostProcessors = joinValues(postProcessors);

            // Assigning will apply default values to missing keys
            projectPath = projectPath;
            searchPaths = searchPaths;
            assemblies = assemblies;
            plugins = plugins;
            this.dataProviders = this.dataProviders;
            this.codeGenerators = this.codeGenerators;
            this.postProcessors = this.postProcessors;
            targetDirectory = targetDirectory;
            contexts = contexts;
        }

        static string joinValues(string[] values) {
            return string.Join(", ", values
                               .Where(value => !string.IsNullOrEmpty(value))
                               .Select(value => value.Trim())
                               .ToArray());
        }

        static string[] separateValues(string values) {
            return values
                    .Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(value => value.Trim())
                    .ToArray();
        }

        public override string ToString() {
            return _config.ToString();
        }
    }
}
