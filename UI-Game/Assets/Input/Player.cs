// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Player : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f1653a23-7f61-4082-b651-bcd4186f67c2"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c418b845-99d3-4f0f-8999-064faf9a0666"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""e2316ca6-9c77-4b67-a2b3-a14588b20d1f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Value"",
                    ""id"": ""b81cb9e3-f060-44bb-856b-23a5a2478f66"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cb62629c-7936-4d97-ba01-d0ce0d76b66c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""ReleaseLeft"",
                    ""type"": ""Button"",
                    ""id"": ""84b06a99-4407-453f-9e50-839cc6042834"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ReleaseRight"",
                    ""type"": ""Button"",
                    ""id"": ""da2873f4-0ed5-4cea-bc3d-58920b4af5b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ReleaseJump"",
                    ""type"": ""Button"",
                    ""id"": ""e231b652-4a8d-4df6-aa25-8072d6e62f1f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ReleaseShoot"",
                    ""type"": ""Button"",
                    ""id"": ""0c53ee15-f571-4eb5-8f5e-0adb14bcfb12"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c6d6fc3-b862-4494-ac54-c3991f548941"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82dd3a67-4135-49a4-a799-f3690b160015"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72d9a81a-d14f-492d-9d87-66ad5f15acd0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""920b2a6d-50e8-4ff8-a54b-8c71fbd2af94"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""940850f9-386e-40b7-9553-516b84d84e68"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae1400ee-3ffb-4030-8efd-8a37e92eae6c"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e926427-d854-445d-86fd-676f0f5046d6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9dc1604f-323b-4ee4-b367-7a32ddc7ec9f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_MoveRight = m_Gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_Gameplay_MoveLeft = m_Gameplay.FindAction("MoveLeft", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_ReleaseLeft = m_Gameplay.FindAction("ReleaseLeft", throwIfNotFound: true);
        m_Gameplay_ReleaseRight = m_Gameplay.FindAction("ReleaseRight", throwIfNotFound: true);
        m_Gameplay_ReleaseJump = m_Gameplay.FindAction("ReleaseJump", throwIfNotFound: true);
        m_Gameplay_ReleaseShoot = m_Gameplay.FindAction("ReleaseShoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_MoveRight;
    private readonly InputAction m_Gameplay_MoveLeft;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_ReleaseLeft;
    private readonly InputAction m_Gameplay_ReleaseRight;
    private readonly InputAction m_Gameplay_ReleaseJump;
    private readonly InputAction m_Gameplay_ReleaseShoot;
    public struct GameplayActions
    {
        private Player m_Wrapper;
        public GameplayActions(Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @MoveRight => m_Wrapper.m_Gameplay_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_Gameplay_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @ReleaseLeft => m_Wrapper.m_Gameplay_ReleaseLeft;
        public InputAction @ReleaseRight => m_Wrapper.m_Gameplay_ReleaseRight;
        public InputAction @ReleaseJump => m_Wrapper.m_Gameplay_ReleaseJump;
        public InputAction @ReleaseShoot => m_Wrapper.m_Gameplay_ReleaseShoot;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                MoveLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                MoveLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                MoveLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                ReleaseLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseLeft;
                ReleaseLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseLeft;
                ReleaseLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseLeft;
                ReleaseRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseRight;
                ReleaseRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseRight;
                ReleaseRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseRight;
                ReleaseJump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseJump;
                ReleaseJump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseJump;
                ReleaseJump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseJump;
                ReleaseShoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseShoot;
                ReleaseShoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseShoot;
                ReleaseShoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReleaseShoot;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                MoveRight.started += instance.OnMoveRight;
                MoveRight.performed += instance.OnMoveRight;
                MoveRight.canceled += instance.OnMoveRight;
                MoveLeft.started += instance.OnMoveLeft;
                MoveLeft.performed += instance.OnMoveLeft;
                MoveLeft.canceled += instance.OnMoveLeft;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                ReleaseLeft.started += instance.OnReleaseLeft;
                ReleaseLeft.performed += instance.OnReleaseLeft;
                ReleaseLeft.canceled += instance.OnReleaseLeft;
                ReleaseRight.started += instance.OnReleaseRight;
                ReleaseRight.performed += instance.OnReleaseRight;
                ReleaseRight.canceled += instance.OnReleaseRight;
                ReleaseJump.started += instance.OnReleaseJump;
                ReleaseJump.performed += instance.OnReleaseJump;
                ReleaseJump.canceled += instance.OnReleaseJump;
                ReleaseShoot.started += instance.OnReleaseShoot;
                ReleaseShoot.performed += instance.OnReleaseShoot;
                ReleaseShoot.canceled += instance.OnReleaseShoot;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnReleaseLeft(InputAction.CallbackContext context);
        void OnReleaseRight(InputAction.CallbackContext context);
        void OnReleaseJump(InputAction.CallbackContext context);
        void OnReleaseShoot(InputAction.CallbackContext context);
    }
}
