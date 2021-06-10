// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""66c74fca-f65b-45b7-b450-69e5fa9adf8c"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""140a3502-8bb8-4bf8-8e62-4ee5dd85b636"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Destroy"",
                    ""type"": ""Button"",
                    ""id"": ""da6eb622-70a0-40dd-9caa-64aba6cfe041"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""5265139a-e3b2-4973-8039-dd054fec89e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""362e2f12-9dc1-4809-8834-24ae7ec34a13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveBack"",
                    ""type"": ""Button"",
                    ""id"": ""db82e7c9-f81b-468a-a151-20b2e8c52d41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""e1724019-46b0-4c79-9f1d-a43a1444e3f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""cf3a01e7-ead4-4b9c-9692-fa1d85227c8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d63096aa-f87e-48dc-b3de-2791355073e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewUp"",
                    ""type"": ""Button"",
                    ""id"": ""bde29ed5-6188-464c-8c30-82ba421fa19b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewDown"",
                    ""type"": ""Button"",
                    ""id"": ""18795660-7d7c-4f34-a1e5-c3bdccc8bb5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewLeft"",
                    ""type"": ""Button"",
                    ""id"": ""c1b31bb9-7bb5-4933-aff7-a0adca2a0918"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewRight"",
                    ""type"": ""Button"",
                    ""id"": ""d35f484d-6c53-4801-86fb-b2b7dbefba42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""View"",
                    ""type"": ""PassThrough"",
                    ""id"": ""49d7a0dd-3255-4b6c-ad36-3099779aae11"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""10c42366-71fc-4abf-8660-2cf029d0375e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlaceBlock"",
                    ""type"": ""Button"",
                    ""id"": ""c01253b7-5f1b-4e3a-b154-55dfa3edc300"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""c26ae133-4baa-4445-ad57-192f7f1e2959"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bfec5138-99fb-4d95-9289-35f3bbb792bb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e71f58b-135e-4a07-8a03-3dba4430d815"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40cffa80-4314-4fff-894c-9e08b872d64c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Destroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9083e057-967f-4c06-aea7-044826a1d70c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Destroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2af83d5-fbfa-419c-bf04-68c0bb19bf94"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f34c374-162c-4427-a8e6-541c699110a4"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""249d5a6a-a6dc-4372-920f-d2c72f65c380"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4374065d-0e96-4615-b398-9cd238e96aa2"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aafaefc7-22fe-4906-bff5-d891c13aaed3"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bde2d97-694d-407a-a629-4a411474c6bb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c200214-13be-46fd-9b11-dd010ba9399d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62b5c8d1-f70c-48d3-b2e3-7afa92980479"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9f8a609-5980-4052-81dd-a45b3f184505"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38b64866-a460-4b56-a2fb-baa93133b385"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29dc5ce3-356c-4bbc-9c2a-a3077fd36365"",
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
                    ""id"": ""55bdc580-adae-4549-83de-fd6db7f94948"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9473886e-91f9-4fa9-8438-03da06417664"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2a2a92a-6698-4bdb-a29b-522e437c8e97"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bb9c3d5-1eba-43e8-aa57-5cb8403ac563"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e4d772c-0402-4d07-be84-7699f4c9fb98"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6d9a582-8128-47d3-af62-86af6291de74"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04e5520c-e313-4aa9-a75e-3cbb9caf39da"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42605e90-915c-4b65-b7de-948e49ec9806"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d4a3dcd-2d10-489f-a453-59b6358d9fe9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""318f4d2f-98aa-4588-8945-2a2a0a21ea51"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""47c2d68d-5c65-457f-a901-517720c94a5e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ae0e71f-c6af-4ee2-80bd-0f2363c7b2ff"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e75f3017-0ecd-4e98-bb62-5a9bf9319429"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""57ce576a-7de6-412c-aa4d-803e2ada0e46"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e1b4b093-952a-4711-9ebe-b75894f18184"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5989f241-e375-40f5-9a23-dedbf152c479"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6ac23b4-c866-4619-a4d2-844083fb09aa"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                    ""name"": """",
                    ""id"": ""46e3ec58-7c0b-425a-b782-27841eeac671"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
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
        m_Gameplay_MoveForward = m_Gameplay.FindAction("MoveForward", throwIfNotFound: true);
        m_Gameplay_Destroy = m_Gameplay.FindAction("Destroy", throwIfNotFound: true);
        m_Gameplay_Save = m_Gameplay.FindAction("Save", throwIfNotFound: true);
        m_Gameplay_Load = m_Gameplay.FindAction("Load", throwIfNotFound: true);
        m_Gameplay_MoveBack = m_Gameplay.FindAction("MoveBack", throwIfNotFound: true);
        m_Gameplay_MoveLeft = m_Gameplay.FindAction("MoveLeft", throwIfNotFound: true);
        m_Gameplay_MoveRight = m_Gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_ViewUp = m_Gameplay.FindAction("ViewUp", throwIfNotFound: true);
        m_Gameplay_ViewDown = m_Gameplay.FindAction("ViewDown", throwIfNotFound: true);
        m_Gameplay_ViewLeft = m_Gameplay.FindAction("ViewLeft", throwIfNotFound: true);
        m_Gameplay_ViewRight = m_Gameplay.FindAction("ViewRight", throwIfNotFound: true);
        m_Gameplay_View = m_Gameplay.FindAction("View", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_PlaceBlock = m_Gameplay.FindAction("PlaceBlock", throwIfNotFound: true);
        m_Gameplay_Scroll = m_Gameplay.FindAction("Scroll", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_MoveForward;
    private readonly InputAction m_Gameplay_Destroy;
    private readonly InputAction m_Gameplay_Save;
    private readonly InputAction m_Gameplay_Load;
    private readonly InputAction m_Gameplay_MoveBack;
    private readonly InputAction m_Gameplay_MoveLeft;
    private readonly InputAction m_Gameplay_MoveRight;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_ViewUp;
    private readonly InputAction m_Gameplay_ViewDown;
    private readonly InputAction m_Gameplay_ViewLeft;
    private readonly InputAction m_Gameplay_ViewRight;
    private readonly InputAction m_Gameplay_View;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_PlaceBlock;
    private readonly InputAction m_Gameplay_Scroll;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveForward => m_Wrapper.m_Gameplay_MoveForward;
        public InputAction @Destroy => m_Wrapper.m_Gameplay_Destroy;
        public InputAction @Save => m_Wrapper.m_Gameplay_Save;
        public InputAction @Load => m_Wrapper.m_Gameplay_Load;
        public InputAction @MoveBack => m_Wrapper.m_Gameplay_MoveBack;
        public InputAction @MoveLeft => m_Wrapper.m_Gameplay_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Gameplay_MoveRight;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @ViewUp => m_Wrapper.m_Gameplay_ViewUp;
        public InputAction @ViewDown => m_Wrapper.m_Gameplay_ViewDown;
        public InputAction @ViewLeft => m_Wrapper.m_Gameplay_ViewLeft;
        public InputAction @ViewRight => m_Wrapper.m_Gameplay_ViewRight;
        public InputAction @View => m_Wrapper.m_Gameplay_View;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @PlaceBlock => m_Wrapper.m_Gameplay_PlaceBlock;
        public InputAction @Scroll => m_Wrapper.m_Gameplay_Scroll;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveForward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveForward;
                @Destroy.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDestroy;
                @Destroy.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDestroy;
                @Destroy.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDestroy;
                @Save.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSave;
                @Load.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLoad;
                @MoveBack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveBack;
                @MoveBack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveBack;
                @MoveBack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveBack;
                @MoveLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @ViewUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewUp;
                @ViewUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewUp;
                @ViewUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewUp;
                @ViewDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewDown;
                @ViewDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewDown;
                @ViewDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewDown;
                @ViewLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewLeft;
                @ViewLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewLeft;
                @ViewLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewLeft;
                @ViewRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewRight;
                @ViewRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewRight;
                @ViewRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnViewRight;
                @View.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @PlaceBlock.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPlaceBlock;
                @PlaceBlock.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPlaceBlock;
                @PlaceBlock.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPlaceBlock;
                @Scroll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @Destroy.started += instance.OnDestroy;
                @Destroy.performed += instance.OnDestroy;
                @Destroy.canceled += instance.OnDestroy;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
                @MoveBack.started += instance.OnMoveBack;
                @MoveBack.performed += instance.OnMoveBack;
                @MoveBack.canceled += instance.OnMoveBack;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ViewUp.started += instance.OnViewUp;
                @ViewUp.performed += instance.OnViewUp;
                @ViewUp.canceled += instance.OnViewUp;
                @ViewDown.started += instance.OnViewDown;
                @ViewDown.performed += instance.OnViewDown;
                @ViewDown.canceled += instance.OnViewDown;
                @ViewLeft.started += instance.OnViewLeft;
                @ViewLeft.performed += instance.OnViewLeft;
                @ViewLeft.canceled += instance.OnViewLeft;
                @ViewRight.started += instance.OnViewRight;
                @ViewRight.performed += instance.OnViewRight;
                @ViewRight.canceled += instance.OnViewRight;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @PlaceBlock.started += instance.OnPlaceBlock;
                @PlaceBlock.performed += instance.OnPlaceBlock;
                @PlaceBlock.canceled += instance.OnPlaceBlock;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnDestroy(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnLoad(InputAction.CallbackContext context);
        void OnMoveBack(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnViewUp(InputAction.CallbackContext context);
        void OnViewDown(InputAction.CallbackContext context);
        void OnViewLeft(InputAction.CallbackContext context);
        void OnViewRight(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnPlaceBlock(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
    }
}
