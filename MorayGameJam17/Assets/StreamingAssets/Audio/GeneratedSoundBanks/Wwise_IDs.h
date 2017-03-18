/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID ERROR_ROOM_MUSIC = 4261961893U;
        static const AkUniqueID LANDSCAPE_PLANET = 4277939909U;
        static const AkUniqueID LANDSCAPE_SHUTTLE = 4004066390U;
        static const AkUniqueID LEVEL_MUSIC = 1244594577U;
        static const AkUniqueID PICKUP = 3978245845U;
        static const AkUniqueID PLAYER_MOVE_END = 3120155140U;
        static const AkUniqueID PLAYER_MOVE_START = 1016620215U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace LANDSCAPE_STATES
        {
            static const AkUniqueID GROUP = 1840018849U;

            namespace STATE
            {
                static const AkUniqueID LANDSCAPE_OUTSIDE_STATE = 1143733786U;
                static const AkUniqueID LANDSCAPE_SHUTTLE_STATE = 1075438296U;
            } // namespace STATE
        } // namespace LANDSCAPE_STATES

        namespace MUSIC_STATES
        {
            static const AkUniqueID GROUP = 1690668539U;

            namespace STATE
            {
                static const AkUniqueID BROKENROOM = 2418495951U;
                static const AkUniqueID LEVEL = 2782712965U;
            } // namespace STATE
        } // namespace MUSIC_STATES

    } // namespace STATES

    namespace SWITCHES
    {
        namespace ROBOT_TRACKS
        {
            static const AkUniqueID GROUP = 4089865534U;

            namespace SWITCH
            {
                static const AkUniqueID GRASS = 4248645337U;
                static const AkUniqueID RUBBLE = 286660663U;
                static const AkUniqueID SHUTTLE = 175273672U;
            } // namespace SWITCH
        } // namespace ROBOT_TRACKS

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID CHARACTER_SOUNDBANK = 2949117636U;
        static const AkUniqueID COMPUTER_SYSTEM_SOUNDBANK = 2406554224U;
        static const AkUniqueID LANDSCAPE_INSIDE_SOUNDBANK = 2307324537U;
        static const AkUniqueID LANDSCAPE_OUTSIDE_SOUNDBANK = 74596838U;
        static const AkUniqueID MUSIC_SOUNDBANK = 3589812408U;
        static const AkUniqueID UI_SOUNDBANK = 2454045173U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
    } // namespace BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__
