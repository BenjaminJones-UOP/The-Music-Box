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
        static const AkUniqueID BATH_TAPS = 2998966135U;
        static const AkUniqueID CLOCK_TICKING = 175705637U;
        static const AkUniqueID COMPLETED_TASK = 849535652U;
        static const AkUniqueID FOOTSTEPSEVENT = 3182336282U;
        static const AkUniqueID GARDEN_AMBIENCE = 1286660161U;
        static const AkUniqueID GENERATORON = 4293911511U;
        static const AkUniqueID GENERATORTURNOFF = 1550918064U;
        static const AkUniqueID GENERATORTURNON = 4058272922U;
        static const AkUniqueID OPEN_BACK_DOOR = 4168667344U;
        static const AkUniqueID OPEN_CLOCK = 1479511750U;
        static const AkUniqueID OPEN_FRONT_DOOR = 2312148644U;
        static const AkUniqueID OPEN_INDOOR_DOOR = 2644199244U;
        static const AkUniqueID PICK_UP_KEY = 2616274570U;
        static const AkUniqueID PULL_PLUG = 277024923U;
        static const AkUniqueID TRAFFICAMBIENCE = 2181904100U;
        static const AkUniqueID WALLHITS = 4067330991U;
        static const AkUniqueID WRONG_TASK = 1906163388U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace FOOTSTEPSSWITCH
        {
            static const AkUniqueID GROUP = 3586861854U;

            namespace STATE
            {
                static const AkUniqueID CARPET = 2412606308U;
                static const AkUniqueID FLOORBOARDS = 774877530U;
                static const AkUniqueID GRASS = 4248645337U;
                static const AkUniqueID STAIRS = 1289942167U;
                static const AkUniqueID STAIRSATTIC = 1677069364U;
                static const AkUniqueID TILES = 3316001432U;
                static const AkUniqueID WETTILES = 644576870U;
            } // namespace STATE
        } // namespace FOOTSTEPSSWITCH

        namespace HITWALL
        {
            static const AkUniqueID GROUP = 4097863548U;

            namespace STATE
            {
                static const AkUniqueID INDOOR = 340398852U;
                static const AkUniqueID OFF = 930712164U;
                static const AkUniqueID OUTDOOR = 144697359U;
                static const AkUniqueID WALL = 2108779961U;
            } // namespace STATE
        } // namespace HITWALL

        namespace TASKCONTROLLER
        {
            static const AkUniqueID GROUP = 170325826U;

            namespace STATE
            {
                static const AkUniqueID TASK0_CLOCKON = 1126201946U;
                static const AkUniqueID TASK1_GENERATORON = 1619525690U;
                static const AkUniqueID TASK2_BATHON = 1914664087U;
                static const AkUniqueID TASK3_ALLOFF = 3975095152U;
            } // namespace STATE
        } // namespace TASKCONTROLLER

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID WALLPAN = 68271166U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
