using System;
using System.Collections.Generic;
using System.Text;
using TestXam.Entities;

namespace TestXam.ViewModels
{
    public class PostDetailViewModel : BaseViewModel
    {
        private long id;
        private long userId;
        private string title;
        private string body;
        public long Id
        {
            get => id;
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }
        public long UserId
        {
            get => userId;
            set
            {
                if (value != userId)
                {
                    userId = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Title
        {
            get => title;
            set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Body
        {
            get => body;
            set
            {
                if (value != body)
                {
                    body = value;
                    OnPropertyChanged();
                }
            }
        }
        public PostDetailViewModel(object postLikeObj)
        {
            StartProcess();
            if (postLikeObj is GetPostResult post)
            {
                Id = post.Id;
                UserId = post.UserId;
                Body = post.Body;
                Title = post.Title;
                EndProcess();
                return;
            }
            EndProcess();
            throw new Exception("Specific cast is not valid");
        }
    }
}
