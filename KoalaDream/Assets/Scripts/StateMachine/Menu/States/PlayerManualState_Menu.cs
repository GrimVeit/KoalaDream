using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManualState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;
    
    private readonly AutoMovePresenter _autoMovePresenter;
    private readonly ManualMovePresenter _manualMovePresenter;
    private readonly IPlayerMoveProvider _moveProvider;
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    public PlayerManualState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, AutoMovePresenter autoMovePresenter, ManualMovePresenter manualMovePresenter, IPlayerMoveProvider moveProvider, IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _autoMovePresenter = autoMovePresenter;
        _manualMovePresenter = manualMovePresenter;
        _moveProvider = moveProvider;
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;
    }

    public void EnterState()
    {
        _storePicturesSelectEventsProvider.OnSelectOpenPicture += ChangeStateToShowPicture;
        _storePicturesSelectEventsProvider.OnSelectClosePicture += ChangeStateToOpenPicture;

        _autoMovePresenter.OnStartMove += ChangeStateToAuto;

        _manualMovePresenter.OnMove += _moveProvider.Move;
    }

    public void ExitState()
    {
        _storePicturesSelectEventsProvider.OnSelectOpenPicture -= ChangeStateToShowPicture;
        _storePicturesSelectEventsProvider.OnSelectClosePicture -= ChangeStateToOpenPicture;

        _autoMovePresenter.OnStartMove -= ChangeStateToAuto;

        _manualMovePresenter.OnMove -= _moveProvider.Move;
    }

    private void ChangeStateToAuto()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromManualToAutoState_Menu>());
    }

    private void ChangeStateToShowPicture()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<ShowPictureState_Menu>());
    }

    private void ChangeStateToOpenPicture()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<OpenPictureState_Menu>());
    }
}
