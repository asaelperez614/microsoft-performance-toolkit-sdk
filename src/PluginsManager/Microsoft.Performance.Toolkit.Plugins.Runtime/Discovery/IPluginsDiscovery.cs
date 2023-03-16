﻿using System;
using System.Collections.Generic;
using Microsoft.Performance.Toolkit.Plugins.Core;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Performance.Toolkit.Plugins.Core.Discovery;
using Microsoft.Performance.Toolkit.Plugins.Runtime.Events;

namespace Microsoft.Performance.Toolkit.Plugins.Runtime.Discovery
{
    public interface IPluginsDiscovery
    {
        IEnumerable<PluginSource> PluginSources { get; }

        event EventHandler<PluginSourceErrorEventArgs> PluginSourceErrorOccured;

        /// <summary>
        ///     Gets all available plugins in their latest versions.
        /// </summary>
        /// <param name="cancellationToken">
        ///     Signals that the caller wishes to cancel the operation.
        /// </param>
        /// <returns>
        ///     A collection of available plugins.
        /// </returns>
        Task<IReadOnlyCollection<AvailablePlugin>> GetAvailablePluginsLatestAsync(CancellationToken cancellationToken);

        /// <summary>
        ///      Gets all available plugins in their latest versions from a given plugin source.
        /// </summary>
        /// <param name="pluginSource">
        ///      The source to discover plugins from.
        /// </param>
        /// <param name="cancellationToken">
        ///     Signals that the caller wishes to cancel the operation.
        /// </param>
        /// <returns>
        ///      A collection of available plugins.
        /// </returns>
        Task<IReadOnlyCollection<AvailablePlugin>> GetAvailablePluginsLatestFromSourceAsync(
            PluginSource pluginSource,
            CancellationToken cancellationToken);

        // TODO: Re-enable when we start to support loading additional resources.
        ///// <summary>
        /////     Loads additional <see cref="IPluginsManagerResource"/>s from <paramref name="directory"/> to this plugin manager.
        ///// </summary>
        ///// <param name="directory">
        /////     The directory to load resource assemblies from.
        ///// </param>
        ///// <returns>
        /////     Whether the loading was successful.
        ///// </returns>
        //bool LoadAdditionalPluginResources(string directory);

        /// <summary>
        ///     Gets all available versions of a plugin by discovering from all plugin sources.
        /// </summary>
        /// <param name="pluginIdentity">
        ///     The identity of the target plugin.
        /// </param>
        /// <param name="cancellationToken">
        ///     Signals that the caller wishes to cancel the operation.
        /// </param>
        /// <returns>
        ///     A collection of available plugins.
        /// </returns>
        Task<IReadOnlyCollection<AvailablePlugin>> GetAllVersionsOfPluginAsync(
            PluginIdentity pluginIdentity,
            CancellationToken cancellationToken);

        /// <summary>
        ///     Gets all available versions of a plugin from a particular source.
        /// </summary>
        /// <param name="pluginSource">
        ///     The plugin source to discover plugins from.
        /// </param>
        /// <param name="pluginIdentity">
        ///     The identity of the target plugin.
        /// </param>
        /// <param name="cancellationToken">
        ///     Signals that the caller wishes to cancel the operation.
        /// </param>
        /// <returns>
        ///     A collection of available plugins.
        /// </returns>
        Task<IReadOnlyCollection<AvailablePlugin>> GetAllVersionsOfPluginFromSourceAsync(
            PluginSource pluginSource,
            PluginIdentity pluginIdentity,
            CancellationToken cancellationToken);

    }
}
