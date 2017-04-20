/*!
 * ASP.NET SignalR JavaScript Library v2.2.1
 * http://signalr.net/
 *
 * Copyright (c) .NET Foundation. All rights reserved.
 * Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
 *
 */

/// <reference path="..\..\SignalR.Client.JS\Scripts\jquery-1.6.4.js" />
/// <reference path="jquery.signalR.js" />
(function ($, window, undefined) {
    /// <param name="$" type="jQuery" />
    "use strict";

    if (typeof ($.signalR) !== "function") {
        throw new Error("SignalR: SignalR is not loaded. Please ensure jquery.signalR-x.js is referenced before ~/signalr/js.");
    }

    var signalR = $.signalR;

    function makeProxyCallback(hub, callback) {
        return function () {
            // Call the client hub method
            callback.apply(hub, $.makeArray(arguments));
        };
    }

    function registerHubProxies(instance, shouldSubscribe) {
        var key, hub, memberKey, memberValue, subscriptionMethod;

        for (key in instance) {
            if (instance.hasOwnProperty(key)) {
                hub = instance[key];

                if (!(hub.hubName)) {
                    // Not a client hub
                    continue;
                }

                if (shouldSubscribe) {
                    // We want to subscribe to the hub events
                    subscriptionMethod = hub.on;
                } else {
                    // We want to unsubscribe from the hub events
                    subscriptionMethod = hub.off;
                }

                // Loop through all members on the hub and find client hub functions to subscribe/unsubscribe
                for (memberKey in hub.client) {
                    if (hub.client.hasOwnProperty(memberKey)) {
                        memberValue = hub.client[memberKey];

                        if (!$.isFunction(memberValue)) {
                            // Not a client hub function
                            continue;
                        }

                        subscriptionMethod.call(hub, memberKey, makeProxyCallback(hub, memberValue));
                    }
                }
            }
        }
    }

    $.hubConnection.prototype.createHubProxies = function () {
        var proxies = {};
        this.starting(function () {
            // Register the hub proxies as subscribed
            // (instance, shouldSubscribe)
            registerHubProxies(proxies, true);

            this._registerSubscribedHubs();
        }).disconnected(function () {
            // Unsubscribe all hub proxies when we "disconnect".  This is to ensure that we do not re-add functional call backs.
            // (instance, shouldSubscribe)
            registerHubProxies(proxies, false);
        });

        proxies['chatHub'] = this.createHubProxy('chatHub'); 
        proxies['chatHub'].client = { };
        proxies['chatHub'].server = {
            send: function (name, message) {
            /// <summary>Calls the Send method on the server-side ChatHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"name\" type=\"String\">Server side type is System.String</param>
            /// <param name=\"message\" type=\"String\">Server side type is System.String</param>
                return proxies['chatHub'].invoke.apply(proxies['chatHub'], $.merge(["Send"], $.makeArray(arguments)));
             }
        };

        proxies['imHub'] = this.createHubProxy('imHub'); 
        proxies['imHub'].client = { };
        proxies['imHub'].server = {
            chatter_ChatterInfo: function () {
            /// <summary>Calls the Chatter_ChatterInfo method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Chatter_ChatterInfo"], $.makeArray(arguments)));
             },

            chatter_ResetUnreadMsg: function (model) {
            /// <summary>Calls the Chatter_ResetUnreadMsg method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IChatter_ResetUnreadMsg</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Chatter_ResetUnreadMsg"], $.makeArray(arguments)));
             },

            fG_GetContacts: function () {
            /// <summary>Calls the FG_GetContacts method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["FG_GetContacts"], $.makeArray(arguments)));
             },

            fG_GetFriends: function () {
            /// <summary>Calls the FG_GetFriends method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["FG_GetFriends"], $.makeArray(arguments)));
             },

            fG_GetGroups: function () {
            /// <summary>Calls the FG_GetGroups method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["FG_GetGroups"], $.makeArray(arguments)));
             },

            gM_AddUsers: function (model) {
            /// <summary>Calls the GM_AddUsers method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IGM_AddUsers</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["GM_AddUsers"], $.makeArray(arguments)));
             },

            gM_Create: function (model) {
            /// <summary>Calls the GM_Create method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IGM_Create</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["GM_Create"], $.makeArray(arguments)));
             },

            gM_Delete: function () {
            /// <summary>Calls the GM_Delete method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["GM_Delete"], $.makeArray(arguments)));
             },

            gM_Exit: function () {
            /// <summary>Calls the GM_Exit method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["GM_Exit"], $.makeArray(arguments)));
             },

            gM_GetGroups: function () {
            /// <summary>Calls the GM_GetGroups method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["GM_GetGroups"], $.makeArray(arguments)));
             },

            gM_GroupInfo: function (model) {
            /// <summary>Calls the GM_GroupInfo method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IGM_GroupInfo</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["GM_GroupInfo"], $.makeArray(arguments)));
             },

            gM_RemoveUsers: function (model) {
            /// <summary>Calls the GM_RemoveUsers method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IGM_RemoveUsers</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["GM_RemoveUsers"], $.makeArray(arguments)));
             },

            group_SendFile: function (model) {
            /// <summary>Calls the Group_SendFile method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IGroup_SendText</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Group_SendFile"], $.makeArray(arguments)));
             },

            group_SendHasRead: function () {
            /// <summary>Calls the Group_SendHasRead method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Group_SendHasRead"], $.makeArray(arguments)));
             },

            group_SendNotice: function () {
            /// <summary>Calls the Group_SendNotice method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Group_SendNotice"], $.makeArray(arguments)));
             },

            group_SendPicture: function (model) {
            /// <summary>Calls the Group_SendPicture method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IGroup_SendText</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Group_SendPicture"], $.makeArray(arguments)));
             },

            group_SendText: function (model) {
            /// <summary>Calls the Group_SendText method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IGroup_SendText</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Group_SendText"], $.makeArray(arguments)));
             },

            hello: function (who, message) {
            /// <summary>Calls the Hello method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"who\" type=\"String\">Server side type is System.String</param>
            /// <param name=\"message\" type=\"String\">Server side type is System.String</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Hello"], $.makeArray(arguments)));
             },

            his_GroupHistory: function (model) {
            /// <summary>Calls the His_GroupHistory method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IHis_GroupHistory</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["His_GroupHistory"], $.makeArray(arguments)));
             },

            his_QueryGroup: function () {
            /// <summary>Calls the His_QueryGroup method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["His_QueryGroup"], $.makeArray(arguments)));
             },

            his_QuerySingle: function () {
            /// <summary>Calls the His_QuerySingle method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["His_QuerySingle"], $.makeArray(arguments)));
             },

            his_SingleHistory: function (model) {
            /// <summary>Calls the His_SingleHistory method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.IHis_SingleHistory</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["His_SingleHistory"], $.makeArray(arguments)));
             },

            single_SendFile: function (model) {
            /// <summary>Calls the Single_SendFile method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.ISingle_SendText</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Single_SendFile"], $.makeArray(arguments)));
             },

            single_SendHasRead: function () {
            /// <summary>Calls the Single_SendHasRead method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Single_SendHasRead"], $.makeArray(arguments)));
             },

            single_SendPicture: function (model) {
            /// <summary>Calls the Single_SendPicture method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.ISingle_SendText</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Single_SendPicture"], $.makeArray(arguments)));
             },

            single_SendText: function (model) {
            /// <summary>Calls the Single_SendText method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
            /// <param name=\"model\" type=\"Object\">Server side type is SignalR_Hubs.Models.InputOut.ISingle_SendText</param>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Single_SendText"], $.makeArray(arguments)));
             },

            stopClient: function () {
            /// <summary>Calls the StopClient method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["StopClient"], $.makeArray(arguments)));
             },

            sys_GroupCreateByMaster: function () {
            /// <summary>Calls the Sys_GroupCreateByMaster method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Sys_GroupCreateByMaster"], $.makeArray(arguments)));
             },

            sys_GroupDeleteByMaster: function () {
            /// <summary>Calls the Sys_GroupDeleteByMaster method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Sys_GroupDeleteByMaster"], $.makeArray(arguments)));
             },

            sys_GroupExitByUser: function () {
            /// <summary>Calls the Sys_GroupExitByUser method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Sys_GroupExitByUser"], $.makeArray(arguments)));
             },

            sys_GroupJoinByUser: function () {
            /// <summary>Calls the Sys_GroupJoinByUser method on the server-side ImHub hub.&#10;Returns a jQuery.Deferred() promise.</summary>
                return proxies['imHub'].invoke.apply(proxies['imHub'], $.merge(["Sys_GroupJoinByUser"], $.makeArray(arguments)));
             }
        };

        return proxies;
    };

    signalR.hub = $.hubConnection("/signalr", { useDefaultPath: false });
    $.extend(signalR, signalR.hub.createHubProxies());

}(window.jQuery, window));