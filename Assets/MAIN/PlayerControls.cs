// GENERATED AUTOMATICALLY FROM 'Assets/MAIN/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e688d954-2a84-4a80-9711-48031c5da66b"",
            ""actions"": [
                {
                    ""name"": ""DotsMovement"",
                    ""type"": ""Button"",
                    ""id"": ""4ab2cba0-d636-404c-a573-5daea48ed6ef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DotsJump"",
                    ""type"": ""Button"",
                    ""id"": ""bec104b7-5830-4cb4-9a52-10d24f36991d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixMovement"",
                    ""type"": ""Button"",
                    ""id"": ""8d7854cc-6c9f-4cd5-9f03-f2f8d25cbc11"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrixJump"",
                    ""type"": ""Button"",
                    ""id"": ""5999d7ec-2bd9-4e95-97f9-f5ba7bc5402e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""right/left"",
                    ""id"": ""1ef2ad91-ff85-44d8-9c37-ae370c6e5deb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cda672f9-3ed1-49ff-bf91-b19627cdbff8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""10436bbb-2bce-4955-a05d-b822e823f3d9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1b53dde7-8194-4962-99ed-11a10267146a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DotsJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""right/left"",
                    ""id"": ""8d74265e-b4e0-4d4c-a871-db5cd14389cc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2c4b8bab-ecb4-449c-b972-f71608af68e9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a4440d8d-cf70-4f2f-ad8f-1731c1c177da"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9e8f9eb3-afe1-4ab4-8e10-24fb5b18edbc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrixJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_DotsMovement = m_Player.FindAction("DotsMovement", throwIfNotFound: true);
        m_Player_DotsJump = m_Player.FindAction("DotsJump", throwIfNotFound: true);
        m_Player_StrixMovement = m_Player.FindAction("StrixMovement", throwIfNotFound: true);
        m_Player_StrixJump = m_Player.FindAction("StrixJump", throwIfNotFound: true);
    }

    ~PlayerControls()
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_DotsMovement;
    private readonly InputAction m_Player_DotsJump;
    private readonly InputAction m_Player_StrixMovement;
    private readonly InputAction m_Player_StrixJump;
    public struct PlayerActions
    {
        private PlayerControls m_Wrapper;
        public PlayerActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DotsMovement => m_Wrapper.m_Player_DotsMovement;
        public InputAction @DotsJump => m_Wrapper.m_Player_DotsJump;
        public InputAction @StrixMovement => m_Wrapper.m_Player_StrixMovement;
        public InputAction @StrixJump => m_Wrapper.m_Player_StrixJump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                DotsMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsMovement;
                DotsMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsMovement;
                DotsMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsMovement;
                DotsJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsJump;
                DotsJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsJump;
                DotsJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDotsJump;
                StrixMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixMovement;
                StrixMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixMovement;
                StrixMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixMovement;
                StrixJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixJump;
                StrixJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixJump;
                StrixJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrixJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                DotsMovement.started += instance.OnDotsMovement;
                DotsMovement.performed += instance.OnDotsMovement;
                DotsMovement.canceled += instance.OnDotsMovement;
                DotsJump.started += instance.OnDotsJump;
                DotsJump.performed += instance.OnDotsJump;
                DotsJump.canceled += instance.OnDotsJump;
                StrixMovement.started += instance.OnStrixMovement;
                StrixMovement.performed += instance.OnStrixMovement;
                StrixMovement.canceled += instance.OnStrixMovement;
                StrixJump.started += instance.OnStrixJump;
                StrixJump.performed += instance.OnStrixJump;
                StrixJump.canceled += instance.OnStrixJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnDotsMovement(InputAction.CallbackContext context);
        void OnDotsJump(InputAction.CallbackContext context);
        void OnStrixMovement(InputAction.CallbackContext context);
        void OnStrixJump(InputAction.CallbackContext context);
    }
}
