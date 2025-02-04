﻿// Copyright © 2018-2021 United States Government as represented by the Administrator
// of the National Aeronautics and Space Administration. All Rights Reserved.

using UnityEngine;
using GSFC.ARVR.MRET.Common.Schemas;

public class AnnotationAction : BaseAction
{
    public enum AnnotationActionType
    {
        StartAnnotation, EndAnnotation, PlayAnnotation,
        PauseAnnotation, StopAnnotation, AnnotationGoTo,
        Unset
    };

    public enum AnnotationType
    {
        Text, Audio, Unset
    };

    private AnnotationActionType actionType = AnnotationActionType.Unset;
    private AnnotationType annotationType = AnnotationType.Unset;
    private string fileNameOfInterest;
    private string partNameOfInterest;
    private int indexOfInterest;

    public static AnnotationAction StartAnnotationAction(ActionTypeAnnotationType type, string fileName, string partName)
    {
        return StartAnnotationAction((type == ActionTypeAnnotationType.Audio) ? AnnotationType.Audio :
            (type == ActionTypeAnnotationType.Text) ? AnnotationType.Text : AnnotationType.Unset, fileName, partName);
    }

    public static AnnotationAction StartAnnotationAction(AnnotationType type, string fileName, string partName)
    {
        return new AnnotationAction()
        {
            actionType = AnnotationActionType.StartAnnotation,
            annotationType = type,
            fileNameOfInterest = fileName,
            partNameOfInterest = partName
        };
    }

    public static AnnotationAction EndAnnotationAction(ActionTypeAnnotationType type, string partName)
    {
        return EndAnnotationAction((type == ActionTypeAnnotationType.Audio) ? AnnotationType.Audio :
            (type == ActionTypeAnnotationType.Text) ? AnnotationType.Text : AnnotationType.Unset, partName);
    }

    public static AnnotationAction EndAnnotationAction(AnnotationType type, string partName)
    {
        return new AnnotationAction()
        {
            actionType = AnnotationActionType.StartAnnotation,
            annotationType = type,
            partNameOfInterest = partName
        };
    }

    public static AnnotationAction PlayAnnotationAction(ActionTypeAnnotationType type, string partName)
    {
        return PlayAnnotationAction((type == ActionTypeAnnotationType.Audio) ? AnnotationType.Audio :
            (type == ActionTypeAnnotationType.Text) ? AnnotationType.Text : AnnotationType.Unset, partName);
    }

    public static AnnotationAction PlayAnnotationAction(AnnotationType type, string partName)
    {
        return new AnnotationAction()
        {
            actionType = AnnotationActionType.StartAnnotation,
            annotationType = type,
            partNameOfInterest = partName
        };
    }

    public static AnnotationAction PauseAnnotationAction(ActionTypeAnnotationType type, string partName)
    {
        return PauseAnnotationAction((type == ActionTypeAnnotationType.Audio) ? AnnotationType.Audio :
            (type == ActionTypeAnnotationType.Text) ? AnnotationType.Text : AnnotationType.Unset, partName);
    }

    public static AnnotationAction PauseAnnotationAction(AnnotationType type, string partName)
    {
        return new AnnotationAction()
        {
            actionType = AnnotationActionType.StartAnnotation,
            annotationType = type,
            partNameOfInterest = partName
        };
    }

    public static AnnotationAction StopAnnotationAction(ActionTypeAnnotationType type, string partName)
    {
        return StopAnnotationAction((type == ActionTypeAnnotationType.Audio) ? AnnotationType.Audio :
            (type == ActionTypeAnnotationType.Text) ? AnnotationType.Text : AnnotationType.Unset, partName);
    }

    public static AnnotationAction StopAnnotationAction(AnnotationType type, string partName)
    {
        return new AnnotationAction()
        {
            actionType = AnnotationActionType.StartAnnotation,
            annotationType = type,
            partNameOfInterest = partName
        };
    }

    public static AnnotationAction AnnotationGoToAction(ActionTypeAnnotationType type, string partName, int index)
    {
        return AnnotationGoToAction((type == ActionTypeAnnotationType.Audio) ? AnnotationType.Audio :
            (type == ActionTypeAnnotationType.Text) ? AnnotationType.Text : AnnotationType.Unset, partName, index);
    }

    public static AnnotationAction AnnotationGoToAction(AnnotationType type, string partName, int index)
    {
        return new AnnotationAction()
        {
            actionType = AnnotationActionType.StartAnnotation,
            annotationType = type,
            partNameOfInterest = partName,
            indexOfInterest = index
        };
    }

    public void PerformAction()
    {
        switch (actionType)
        {
            case AnnotationActionType.StartAnnotation:
                if (annotationType != AnnotationType.Unset && fileNameOfInterest != null && partNameOfInterest != null)
                {
                    GameObject part = GameObject.Find("LoadedProject/GameObjects/" + partNameOfInterest);
                    if (part)
                    {
                        if (annotationType == AnnotationType.Audio)
                        {
                            AudioPlayer aPlayer = part.AddComponent<AudioPlayer>();
                            aPlayer.Deserialize(fileNameOfInterest);
                            aPlayer.Play();
                        }
                        else
                        {
                            TextAnnotationPlayer tPlayer = part.AddComponent<TextAnnotationPlayer>();
                            tPlayer.Deserialize(fileNameOfInterest);
                            tPlayer.Play();
                        }
                    }
                }
                break;

            case AnnotationActionType.EndAnnotation:
                if (annotationType != AnnotationType.Unset && partNameOfInterest != null)
                {
                    GameObject part = GameObject.Find("LoadedProject/GameObjects/" + partNameOfInterest);
                    if (part)
                    {
                        if (annotationType == AnnotationType.Audio)
                        {
                            AudioPlayer aPlayer = part.GetComponentInChildren<AudioPlayer>();
                            if (aPlayer)
                            {
                                aPlayer.Stop();
                                Destroy(aPlayer);
                            }
                        }
                        else
                        {
                            TextAnnotationPlayer tPlayer = part.GetComponentInChildren<TextAnnotationPlayer>();
                            if (tPlayer)
                            {
                                tPlayer.Stop();
                                Destroy(tPlayer);
                            }
                        }
                    }
                }
                break;

            case AnnotationActionType.PlayAnnotation:
                if (annotationType != AnnotationType.Unset && partNameOfInterest != null)
                {
                    GameObject part = GameObject.Find("LoadedProject/GameObjects/" + partNameOfInterest);
                    if (part)
                    {
                        if (annotationType == AnnotationType.Audio)
                        {
                            AudioPlayer aPlayer = part.GetComponentInChildren<AudioPlayer>();
                            if (aPlayer)
                            {
                                aPlayer.Play();
                            }
                        }
                        else
                        {
                            TextAnnotationPlayer tPlayer = part.GetComponentInChildren<TextAnnotationPlayer>();
                            if (tPlayer)
                            {
                                tPlayer.Play();
                            }
                        }
                    }
                }
                break;

            case AnnotationActionType.PauseAnnotation:
                if (annotationType != AnnotationType.Unset && partNameOfInterest != null)
                {
                    GameObject part = GameObject.Find("LoadedProject/GameObjects/" + partNameOfInterest);
                    if (part)
                    {
                        if (annotationType == AnnotationType.Audio)
                        {
                            AudioPlayer aPlayer = part.GetComponentInChildren<AudioPlayer>();
                            if (aPlayer)
                            {
                                aPlayer.Pause();
                            }
                        }
                        else
                        {
                            TextAnnotationPlayer tPlayer = part.GetComponentInChildren<TextAnnotationPlayer>();
                            if (tPlayer)
                            {
                                tPlayer.Pause();
                            }
                        }
                    }
                }
                break;

            case AnnotationActionType.StopAnnotation:
                if (annotationType != AnnotationType.Unset && partNameOfInterest != null)
                {
                    GameObject part = GameObject.Find("LoadedProject/GameObjects/" + partNameOfInterest);
                    if (part)
                    {
                        if (annotationType == AnnotationType.Audio)
                        {
                            AudioPlayer aPlayer = part.GetComponentInChildren<AudioPlayer>();
                            if (aPlayer)
                            {
                                aPlayer.Stop();
                            }
                        }
                        else
                        {
                            TextAnnotationPlayer tPlayer = part.GetComponentInChildren<TextAnnotationPlayer>();
                            if (tPlayer)
                            {
                                tPlayer.Stop();
                            }
                        }
                    }
                }
                break;

            case AnnotationActionType.AnnotationGoTo:
                if (annotationType != AnnotationType.Unset)
                {
                    if (annotationType != AnnotationType.Unset && partNameOfInterest != null && indexOfInterest > -1)
                    {
                        GameObject part = GameObject.Find("LoadedProject/GameObjects/" + partNameOfInterest);
                        if (part)
                        {
                            if (annotationType == AnnotationType.Text)
                            {
                                TextAnnotationPlayer tPlayer = part.GetComponentInChildren<TextAnnotationPlayer>();
                                if (tPlayer)
                                {
                                    tPlayer.GoTo(indexOfInterest);
                                }
                            }
                        }
                    }
                }
                break;

            case AnnotationActionType.Unset:
            default:
                break;
        }
    }

    public override ActionType Serialize()
    {
        ActionType sAction = new ActionType();

        switch (actionType)
        {
            case AnnotationActionType.AnnotationGoTo:
                sAction.Type = ActionTypeType.AnnotationGoTo;
                break;

            case AnnotationActionType.EndAnnotation:
                sAction.Type = ActionTypeType.EndAnnotation;
                break;

            case AnnotationActionType.PauseAnnotation:
                sAction.Type = ActionTypeType.PauseAnnotation;
                break;

            case AnnotationActionType.PlayAnnotation:
                sAction.Type = ActionTypeType.PlayAnnotation;
                break;

            case AnnotationActionType.StartAnnotation:
                sAction.Type = ActionTypeType.StartAnnotation;
                break;

            case AnnotationActionType.StopAnnotation:
                sAction.Type = ActionTypeType.StopAnnotation;
                break;

            case AnnotationActionType.Unset:
            default:
                sAction.Type = ActionTypeType.Unset;
                break;
        }

        switch (annotationType)
        {
            case AnnotationType.Audio:
                sAction.AnnotationType = ActionTypeAnnotationType.Audio;
                break;

            case AnnotationType.Text:
                sAction.AnnotationType = ActionTypeAnnotationType.Text;
                break;

            case AnnotationType.Unset:
            default:
                sAction.AnnotationType = ActionTypeAnnotationType.Unset;
                break;
        }

        sAction.FileName = fileNameOfInterest;
        sAction.PartName = partNameOfInterest;
        sAction.Index = indexOfInterest;

        return sAction;
    }
}