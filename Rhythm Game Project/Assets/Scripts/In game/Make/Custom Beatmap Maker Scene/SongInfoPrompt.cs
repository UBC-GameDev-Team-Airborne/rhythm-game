using CustomBeatmapMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongInfoPrompt : ClickableUI
{
    public GameObject FileNameObject;
    public GameObject TitleObject;
    public GameObject ArtistObject;
    public GameObject GenresObject;
    public GameObject LanguageObject;
    public GameObject IsOriginalObject;
    public GameObject BPMObject;
    public GameObject DurationObject;
    public GameObject PreviewRange1Object;
    public GameObject PreviewRange2Object;
    public GameObject DifficultyObject;

    private InputField _fileNameField;
    private InputField _titleField;
    private InputField _artistField;
    private InputField _genresField;
    private InputField _languageField;
    private Dropdown _isOriginalDropdown;
    private InputField _bpmField;
    private InputField _durationField;
    private InputField _previewRange1Field;
    private InputField _previewRange2Field;
    private Dropdown _difficultyDropdown;
    
    void Start()
    {
        GetComponents();
        ResetFields();
        MakeInvisible();
    }
    public void MakeVisible()
    {
        if (Status.Metadata != null) RecoverFields();
        gameObject.SetActive(true);
    }

    public void MakeInvisible()
    {
        gameObject.SetActive(false);
    }

    public void SetMetadata()
    {
        GetComponents();
        Data.SongData metadata = new Data.SongData();


        metadata.SongFileName = _fileNameField.text;

        metadata.Title = _titleField.text;

        //metadata.Artist = _artistField.text;

        metadata.Genres = Data.SongData.CommaDelimitedStringToGenres(_genresField.text);

        metadata.Language = _languageField.text;

        int isOriginalIndex = _isOriginalDropdown.value;
        metadata.IsOriginal = _isOriginalDropdown.options[isOriginalIndex].text == "True";

        if (int.TryParse(_bpmField.text, out int bpm)) metadata.BPM = bpm;

        if (int.TryParse(_durationField.text, out int duration)) metadata.Duration = duration;

        if (int.TryParse(_previewRange1Field.text, out int previewRange1) && int.TryParse(_previewRange2Field.text, out int previewRange2))
        {
            metadata.PreviewRange = (previewRange1, previewRange2);
        }

        int difficultyIndex = _difficultyDropdown.value;
        string diffycultyString = _difficultyDropdown.options[difficultyIndex].text;
        metadata.Difficulty = Data.SongData.StringToDifficulty(diffycultyString);


        if (!metadata.AFieldIsNull()) Status.Metadata = metadata;
        MakeInvisible();
        Status.MouseIsHoveringClickableUI = false;
    }

    void GetComponents()
    {
        _fileNameField = FileNameObject.GetComponent<InputField>();
        _titleField = TitleObject.GetComponent<InputField>();
        _artistField = ArtistObject.GetComponent<InputField>();
        _genresField = GenresObject.GetComponent<InputField>();
        _languageField = LanguageObject.GetComponent<InputField>();
        _isOriginalDropdown = IsOriginalObject.GetComponent<Dropdown>();
        _bpmField = BPMObject.GetComponent<InputField>();
        _durationField = DurationObject.GetComponent<InputField>();
        _previewRange1Field = PreviewRange1Object.GetComponent<InputField>();
        _previewRange2Field = PreviewRange2Object.GetComponent<InputField>();
        _difficultyDropdown = DifficultyObject.GetComponent<Dropdown>();
    }

    void ResetFields()
    {
        _fileNameField.text = null;
        _titleField.text = null;
        _artistField.text = null;
        _genresField.text = null;
        _languageField.text = null;
        _isOriginalDropdown.value = 0;
        _bpmField.text = null;
        _durationField.text = null;
        _previewRange1Field.text = null;
        _previewRange2Field.text = null;
        _difficultyDropdown.value = 0;
    }

    void RecoverFields()
    {
        Data.SongData metadata = Status.Metadata;
        if (metadata == null) return;

        _fileNameField.text = metadata.SongFileName;
        _titleField.text = metadata.Title;
        //_artistField.text = metadata.Artist;
        _genresField.text = Data.SongData.GenresToCommaDelimitedString(metadata.Genres);
        _languageField.text = metadata.Language;
        _isOriginalDropdown.value = (bool) metadata.IsOriginal ? 1 : 0;
        _bpmField.text = metadata.BPM.ToString();
        _durationField.text = metadata.Duration.ToString();
        _previewRange1Field.text = metadata.PreviewRange.Item1.ToString();
        _previewRange2Field.text = metadata.PreviewRange.Item2.ToString();
        _difficultyDropdown.value = (int) metadata.Difficulty;
    }
}